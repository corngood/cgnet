namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using All = global::OpenTK.Graphics.OpenGL.All;

    using BeginMode = global::OpenTK.Graphics.OpenGL.BeginMode;

    using CgNet;
    using CgNet.GL;

    using ClearBufferMask = global::OpenTK.Graphics.OpenGL.ClearBufferMask;

    using EnableCap = global::OpenTK.Graphics.OpenGL.EnableCap;

    using ExampleBrowser.Data;

    using GL = global::OpenTK.Graphics.OpenGL.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics;
    using global::OpenTK.Input;

    using MatrixMode = global::OpenTK.Graphics.OpenGL.MatrixMode;

    using PixelStoreParameter = global::OpenTK.Graphics.OpenGL.PixelStoreParameter;

    using TextureParameterName = global::OpenTK.Graphics.OpenGL.TextureParameterName;

    using TextureTarget = global::OpenTK.Graphics.OpenGL.TextureTarget;

    [ExampleDescription(NodePath = "OpenTK/Basic/27 Projective Texturing")]
    public class ProjectiveTexturing : Example
    {
        #region Fields

        private float eyeAngle = 0.53f; /* Angle in radians eye rotates around scene. */
        private float eyeHeight = 5.0f; /* Vertical height of light. */
        private float[] Kd = { 1, 1, 1 }; /* White. */
        private float lightAngle = -0.4f; /* Angle light rotates around scene. */
        private float lightHeight = 2.0f; /* Vertical height of light. */
        private Parameter myCgVertexParam_modelViewProj, myCgVertexParam_Kd, myCgVertexParam_lightPosition, myCgVertexParam_textureMatrix;
        string myVertexProgramFileName = "Data/C9E5v_projTex.cg",
            /* Page 254 */    myVertexProgramName = "C9E5v_projTex",
                          myFragmentProgramFileName = "Data/C9E6f_projTex.cg",
            /* Page 254 */    myFragmentProgramName = "C9E6f_projTex";
        private float[] projectionMatrix = new float[16];
        private ProfileType vertexProfile, fragmentProfile;
        private Program vertexProgram, fragmentProgram;

        #endregion Fields

        #region Constructors

        public ProjectiveTexturing()
            : base("27_projective_texturing", 600, 400)
        {
        }

        #endregion Constructors

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.1f, 0.1f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            this.CgContext = CgNet.Context.Create();

            CgGL.SetDebugMode(false);
            this.CgContext.ParameterSettingMode = ParameterSettingMode.Deferred;
            this.CgContext.SetManageTextureParameters(true);

            this.vertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.vertexProfile);

            this.vertexProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    this.myVertexProgramFileName, /* Name of file containing program */
                    this.vertexProfile, /* Profile: OpenGL ARB vertex program */
                    this.myVertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            this.vertexProgram.Load();

            this.myCgVertexParam_modelViewProj = this.vertexProgram.GetNamedParameter("modelViewProj");
            this.myCgVertexParam_lightPosition = this.vertexProgram.GetNamedParameter("lightPosition");
            this.myCgVertexParam_Kd = this.vertexProgram.GetNamedParameter("Kd");
            this.myCgVertexParam_textureMatrix = this.vertexProgram.GetNamedParameter("textureMatrix");

            /* Set light source color parameters once. */
            this.myCgVertexParam_Kd.Set(this.Kd);

            this.fragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(this.fragmentProfile);

            /* Specify "color passthrough" fragment program with a string. */
            this.fragmentProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    myFragmentProgramFileName,
                    this.fragmentProfile, /* Profile: latest fragment profile */
                    myFragmentProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            this.fragmentProgram.Load();
            setupDemonSampler();
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            /* World-space positions for light and eye. */
            float[] eyePosition = {
                                      10*(float)Math.Sin(eyeAngle),
                                      eyeHeight,
                                      10*(float)Math.Cos(eyeAngle),
                                      1
                                  };
            float[] lightPosition = {
                                        4.5f * (float)Math.Sin(this.lightAngle),
                                        lightHeight,
                                        4.5f * (float)Math.Cos(this.lightAngle),
                                        1
                                    };
            float[] center = { 0, 0, 0 };  /* eye and light point at the origin */
            float[] up = { 0, 1, 0 };      /* up is positive Y direction */

            float[] translateMatrix = new float[16],
                rotateMatrix = new float[16],
                modelMatrix = new float[16],
                invModelMatrix = new float[16],
                    eyeViewMatrix = new float[16],
                    modelViewMatrix = new float[16],
                    modelViewProjMatrix = new float[16],
                    textureMatrix = new float[16],
                    lightViewMatrix = new float[16];
            float[] objSpaceLightPosition = new float[4];

            BuildLookAtMatrix(eyePosition[0], eyePosition[1], eyePosition[2],
                              center[0], center[1], center[2],
                              up[0], up[1], up[2],
                              eyeViewMatrix);

            BuildLookAtMatrix(lightPosition[0], lightPosition[1], lightPosition[2],
                  center[0], center[1], center[2],
                  up[0], -up[1], up[2],
                  lightViewMatrix);

            this.vertexProgram.Bind();
            CgGL.EnableProfile(this.vertexProfile);

            this.fragmentProgram.Bind();
            CgGL.EnableProfile(this.fragmentProfile);

            /* modelView = rotateMatrix * translateMatrix */
            MakeRotateMatrix(70, 1, 1, 1, rotateMatrix);
            MakeTranslateMatrix(2, 0, 0, translateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space light positions to sphere's object-space. */
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            this.myCgVertexParam_lightPosition.Set3(objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, eyeViewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, projectionMatrix, modelViewMatrix);

            buildTextureMatrix(lightViewMatrix, modelMatrix, textureMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.myCgVertexParam_modelViewProj.SetMatrix(modelViewProjMatrix);
            myCgVertexParam_textureMatrix.SetMatrix(textureMatrix);
            this.vertexProgram.UpdateParameters();
            this.fragmentProgram.UpdateParameters();
            NativeMethods.glutSolidSphere(2.0, 40, 40);

            /*** Render solid cube ***/

            /* modelView = viewMatrix * translateMatrix */
            MakeTranslateMatrix(-2, -1.0f, 0, translateMatrix);
            MakeRotateMatrix(90, 1, 0, 0, rotateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            this.myCgVertexParam_lightPosition.Set3(objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, eyeViewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, this.projectionMatrix, modelViewMatrix);

            buildTextureMatrix(lightViewMatrix, modelMatrix, textureMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.myCgVertexParam_modelViewProj.SetMatrix(modelViewProjMatrix);
            this.myCgVertexParam_textureMatrix.SetMatrix(textureMatrix);
            this.vertexProgram.UpdateParameters();
            this.fragmentProgram.UpdateParameters();
            NativeMethods.glutSolidCube(2.5);

            /*** Render floor ***/

            /* modelView = translateMatrix */
            MultMatrix(modelViewProjMatrix, projectionMatrix, eyeViewMatrix);
            MakeTranslateMatrix(0, 0, 0, modelMatrix);
            buildTextureMatrix(lightViewMatrix, modelMatrix, textureMatrix);

            myCgVertexParam_lightPosition.Set3(lightPosition);
            myCgVertexParam_modelViewProj.SetMatrix(modelViewProjMatrix);
            myCgVertexParam_textureMatrix.SetMatrix(textureMatrix);

            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();

            GL.Enable(EnableCap.CullFace);

            GL.Begin(BeginMode.Quads);
            {
                GL.Normal3(0f, 1f, 0f);
                GL.Vertex3(12f, -2, -12);
                GL.Vertex3(-12f, -2, -12);
                GL.Vertex3(-12f, -2, 12);
                GL.Vertex3(12f, -2, 12);

                GL.Normal3(0f, 0, 1);
                GL.Vertex3(-12f, -2, -12);
                GL.Vertex3(12f, -2, -12);
                GL.Vertex3(12f, 10, -12);
                GL.Vertex3(-12f, 10, -12);

                GL.Normal3(0f, 0, -1);
                GL.Vertex3(12f, -2, 12);
                GL.Vertex3(-12f, -2, 12);
                GL.Vertex3(-12f, 10, 12);
                GL.Vertex3(12f, 10, 12);

                GL.Normal3(0f, -1, 0);
                GL.Vertex3(-12f, 10, -12);
                GL.Vertex3(12f, 10, -12);
                GL.Vertex3(12f, 10, 12);
                GL.Vertex3(-12f, 10, 12);

                GL.Normal3(1f, 0, 0);
                GL.Vertex3(-12f, -2, 12);
                GL.Vertex3(-12f, -2, -12);
                GL.Vertex3(-12f, 10, -12);
                GL.Vertex3(-12f, 10, 12);

                GL.Normal3(-1f, 0, 0);
                GL.Vertex3(12f, -2, -12);
                GL.Vertex3(12f, -2, 12);
                GL.Vertex3(12f, 10, 12);
                GL.Vertex3(12f, 10, -12);
            }
            GL.End();

            GL.Disable(EnableCap.CullFace);

            CgGL.DisableProfile(vertexProfile);

            CgGL.DisableProfile(fragmentProfile);

            /*** Render light as white cone ***/

            /* modelView = translateMatrix */
            MakeTranslateMatrix(lightPosition[0], lightPosition[1], lightPosition[2],
              modelMatrix);

            /* modelViewMatrix = eyeViewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, eyeViewMatrix, modelMatrix);

            GL.PushMatrix();
            /* glLoadMatrixf expects a column-major matrix but Cg matrices are
               row-major (matching C/C++ arrays) so used loadMVP to transpose
               the Cg version. */
            loadMVP(modelViewMatrix);
            GL.Color3(1f, 1, 1); /* make sure current color is white */
            NativeMethods.glutSolidSphere(0.15, 30, 30);
            GL.PopMatrix();

            this.SwapBuffers();
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            this.Reshape(this.Width, this.Height);
            GL.Viewport(0, 0, this.Width, this.Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            this.vertexProgram.Dispose();
            this.fragmentProgram.Dispose();
            this.CgContext.Dispose();
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            this.lightAngle += 0.008f; /* Add a small angle (in radians). */
            if (this.lightAngle > 2 * Pi)
            {
                this.lightAngle -= 2 * Pi;
            }

            if (this.Keyboard[Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #region Private Static Methods

        static void makeClipToTextureMatrix(float[] m)
        {
            m[0] = 0.5f; m[1] = 0; m[2] = 0; m[3] = 0.5f;
            m[4] = 0; m[5] = 0.5f; m[6] = 0; m[7] = 0.5f;
            m[8] = 0; m[9] = 0; m[10] = 0.5f; m[11] = 0.5f;
            m[12] = 0; m[13] = 0; m[14] = 0; m[15] = 1;
        }

        #endregion Private Static Methods

        #region Private Methods

        void buildTextureMatrix(float[] viewMatrix, float[] modelMatrix, float[] textureMatrix)
        {
            float[] eyeToClipMatrix = new float[16];
            float[] modelViewMatrix = new float[16];

            const float fieldOfView = 50.0f;
            const float aspectRatio = 1;
            float[] textureProjectionMatrix = new float[16];
            float[] clipToTextureMatrix = new float[16];

            /* Build texture projection matrix once. */
            BuildPerspectiveMatrix(fieldOfView, aspectRatio,
                                   0.25, 20.0,  /* Znear and Zfar */
                                   textureProjectionMatrix);

            makeClipToTextureMatrix(clipToTextureMatrix);

            /* eyeToClip = clipToTexture * textureProjection */
            MultMatrix(eyeToClipMatrix,
               clipToTextureMatrix, textureProjectionMatrix);

            /* modelView = view * model */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);
            /* texture = eyeToClip * modelView */
            MultMatrix(textureMatrix, eyeToClipMatrix, modelViewMatrix);
        }

        void loadMVP(float[] modelView)
        {
            float[] transpose = new float[16];
            int i, j;

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    transpose[i * 4 + j] = modelView[j * 4 + i];
                }
            }
            GL.LoadMatrix(transpose);
        }

        private void Reshape(int width, int height)
        {
            double aspectRatio = (float)width / height;
            const double FieldOfView = 40.0;

            /* Build projection matrix once. */
            BuildPerspectiveMatrix(FieldOfView, aspectRatio,
                                   1.0, 50.0, /* Znear and Zfar */
                                   this.projectionMatrix);

            /* Light drawn with fixed-function transformation so also load same
               projection matrix in fixed-function projection matrix. */
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Glu.Perspective(FieldOfView, aspectRatio,
                           1.0, 50.0);  /* Znear and Zfar */
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void setupDemonSampler()
        {
            int texobj = 666;
            Parameter sampler;

            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1); /* Tightly packed texture data. */

            GL.BindTexture(TextureTarget.Texture2D, texobj);
            /* Load demon decal texture with mipmaps. */

            global::OpenTK.Graphics.Glu.Build2DMipmap(global::OpenTK.Graphics.TextureTarget.Texture2D, (int)All.Rgb8,
              128, 128, global::OpenTK.Graphics.PixelFormat.Rgb, global::OpenTK.Graphics.PixelType.UnsignedByte, ImageDemon.Array);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.LinearMipmapLinear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor, Kd);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, 0x812D);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, 0x812D);

            sampler = fragmentProgram.GetNamedParameter("projectiveMap");
            sampler.SetTexture(texobj);
        }

        #endregion Private Methods

        #endregion Methods
    }
}