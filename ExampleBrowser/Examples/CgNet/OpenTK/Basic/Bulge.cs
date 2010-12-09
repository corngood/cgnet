namespace ExampleBrowser.Examples.CgNet.OpenTK.Basic
{
    using System;
    using System.Runtime.InteropServices;

    using global::CgNet;
    using global::CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "CgNet/OpenTK/Basic/14 Bulge")]
    public class Bulge : Example
    {
        #region Fields

        const float myPi = 3.14159265358979323846f;
        private const string MyVertexProgramFileName = "Data/C6E1v_bulge.cg";
        private const string MyVertexProgramName = "C6E1v_bulge";

        static float lightVelocity = 0.008f;
        static float timeFlow = 0.01f;

        private IntPtr myCgVertexParam_modelViewProj, myCgVertexParam_time, myCgVertexParam_frequency, myCgVertexParam_scaleFactor, myCgVertexParam_Kd, myCgVertexParam_shininess, myCgVertexParam_eyePosition, myCgVertexParam_lightPosition, myCgVertexParam_lightColor, myCgLightVertexParam_modelViewProj;
        private ProfileType myCgVertexProfile, myCgFragmentProfile;
        private IntPtr myCgVertexProgram, myCgFragmentProgram, myCgLightVertexProgram;
        float myLightAngle = -0.4f; /* Angle light rotates around scene. */
        float[] myLightColor = { 0.95f, 0.95f, 0.95f }; /* White */
        float[] myProjectionMatrix = new float[16];
        float myTime = 0.0f; /* Timing of bulge. */

        #endregion Fields

        #region Constructors

        public Bulge()
            : base("14_bulge")
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
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f); /* Blue background */
            GL.Enable(EnableCap.DepthTest);
            this.MyCgContext = Cg.CreateContext();
            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.MyCgContext, ParameterSettingMode.Deferred);

            this.myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.myCgVertexProfile);

            this.myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyVertexProgramFileName, /* Name of file containing program */
                    this.myCgVertexProfile, /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            CgGL.LoadProgram(this.myCgVertexProgram);

            myCgVertexParam_modelViewProj = Cg.GetNamedParameter(myCgVertexProgram, "modelViewProj");
            myCgVertexParam_time = Cg.GetNamedParameter(myCgVertexProgram, "time");
            myCgVertexParam_frequency = Cg.GetNamedParameter(myCgVertexProgram, "frequency");
            myCgVertexParam_scaleFactor = Cg.GetNamedParameter(myCgVertexProgram, "scaleFactor");
            myCgVertexParam_Kd = Cg.GetNamedParameter(myCgVertexProgram, "Kd");
            myCgVertexParam_shininess = Cg.GetNamedParameter(myCgVertexProgram, "shininess");
            myCgVertexParam_eyePosition = Cg.GetNamedParameter(myCgVertexProgram, "eyePosition");
            myCgVertexParam_lightPosition = Cg.GetNamedParameter(myCgVertexProgram, "lightPosition");
            myCgVertexParam_lightColor = Cg.GetNamedParameter(myCgVertexProgram, "lightColor");

            /* Set light source color parameters once. */
            Cg.SetParameter(myCgVertexParam_lightColor, myLightColor);

            Cg.SetParameter(myCgVertexParam_scaleFactor, 0.3f);
            Cg.SetParameter(myCgVertexParam_frequency, 2.4f);
            Cg.SetParameter(myCgVertexParam_shininess, 35f);

            this.myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(this.myCgFragmentProfile);

            this.myCgFragmentProgram =
                Cg.CreateProgram(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    "float4 main(float4 c : COLOR) : COLOR { return c; }",
                    this.myCgFragmentProfile, /* Profile: OpenGL ARB vertex program */
                    "main", /* Entry function name */
                    null); /* No extra compiler options */
            CgGL.LoadProgram(this.myCgFragmentProgram);

            /* Specify vertex program for rendering the light source with a string. */
            myCgLightVertexProgram =
              Cg.CreateProgram(
                MyCgContext,              /* Cg runtime context */
                ProgramType.Source,                /* Program in human-readable form */
                @"void main(inout float4 p : POSITION,
                uniform float4x4 modelViewProj,
                out float4 c : COLOR)
                { p = mul(modelViewProj, p); c = float4(1,1,0,1); }",
                myCgVertexProfile,        /* Profile: latest fragment profile */
                "main",                   /* Entry function name */
                null); /* No extra compiler options */

            CgGL.LoadProgram(myCgLightVertexProgram);

            myCgLightVertexParam_modelViewProj =
              Cg.GetNamedParameter(myCgLightVertexProgram, "modelViewProj");
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
            float[] eyePosition = { 0, 0, 13, 1 };
            float[] lightPosition = { (float)(5 * Math.Sin(myLightAngle)), 1.5f, (float)(5 * Math.Cos(myLightAngle)), 1 };

            float[] translateMatrix = new float[16], rotateMatrix = new float[16], modelMatrix = new float[16], invModelMatrix = new float[16],
                viewMatrix = new float[16], modelViewMatrix = new float[16], modelViewProjMatrix = new float[16];
            float[] objSpaceEyePosition = new float[4], objSpaceLightPosition = new float[4];

            Cg.SetParameter(myCgVertexParam_time, myTime);

            BuildLookAtMatrix(eyePosition[0], eyePosition[1], eyePosition[2],
                              0, 0, 0,
                              0, 1, 0,
                              viewMatrix);

            CgGL.EnableProfile(myCgVertexProfile);

            CgGL.EnableProfile(myCgFragmentProfile);

            CgGL.BindProgram(myCgVertexProgram);

            CgGL.BindProgram(myCgFragmentProgram);

            /*** Render green solid bulging sphere ***/

            /* modelView = rotateMatrix * translateMatrix */
            MakeRotateMatrix(70, 1, 1, 1, rotateMatrix);
            MakeTranslateMatrix(2.2f, 1, 0.2f, translateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceEyePosition, invModelMatrix, eyePosition);
            Cg.SetParameter3(myCgVertexParam_eyePosition, objSpaceEyePosition);
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            Cg.SetParameter3(myCgVertexParam_lightPosition, objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.SetMatrixParameter(myCgVertexParam_modelViewProj, modelViewProjMatrix);
            Cg.SetParameter(myCgVertexParam_Kd, 0.1f, 0.7f, 0.1f, 1);  /* Green */
            Cg.UpdateProgramParameters(myCgVertexProgram);
            glutSolidSphere(1.0, 40, 40);

            /*** Render red solid bulging torus ***/

            /* modelView = viewMatrix * translateMatrix */
            MakeTranslateMatrix(-2, -1.5f, 0, translateMatrix);
            MakeRotateMatrix(55, 1, 0, 0, rotateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceEyePosition, invModelMatrix, eyePosition);
            Cg.SetParameter3(myCgVertexParam_eyePosition, objSpaceEyePosition);
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            Cg.SetParameter3(myCgVertexParam_lightPosition, objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.SetMatrixParameter(myCgVertexParam_modelViewProj, modelViewProjMatrix);
            Cg.SetParameter(myCgVertexParam_Kd, 0.8f, 0.1f, 0.1f, 1);  /* Red */
            Cg.UpdateProgramParameters(myCgVertexProgram);
            glutSolidTorus(0.15, 1.7, 40, 40);

            /*** Render light as emissive yellow ball ***/

            CgGL.BindProgram(myCgLightVertexProgram);

            /* modelView = translateMatrix */
            MakeTranslateMatrix(lightPosition[0], lightPosition[1], lightPosition[2],
              modelMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.SetMatrixParameter(myCgLightVertexParam_modelViewProj,
              modelViewProjMatrix);
            Cg.UpdateProgramParameters(myCgVertexProgram);
            glutSolidSphere(0.1, 12, 12);

            CgGL.DisableProfile(myCgVertexProfile);

            CgGL.DisableProfile(myCgFragmentProfile);

            this.SwapBuffers();
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);

            Reshape(this.Width, this.Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            Cg.DestroyProgram(this.myCgVertexProgram);
            Cg.DestroyProgram(this.myCgFragmentProgram);
            Cg.DestroyContext(this.MyCgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            /* Repeat rotating light around front 180 degrees. */
            if (myLightAngle > myPi / 2)
            {
                myLightAngle = myPi / 2;
                lightVelocity = -lightVelocity;
            }
            else if (myLightAngle < -myPi / 2)
            {
                myLightAngle = -myPi / 2;
                lightVelocity = -lightVelocity;
            }
            myLightAngle += lightVelocity;  /* Add a small angle (in radians). */

            /* Repeatedly advance and rewind time. */
            if (myTime > 10)
            {
                myTime = 10;
                timeFlow = -timeFlow;
            }
            else if (myTime < 0)
            {
                myTime = 0;
                timeFlow = -timeFlow;
            }
            myTime += timeFlow;  /* Add time delta. */

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        [DllImport("glut32.dll")]
        private static extern void glutSolidSphere(double radius, int slices, int stacks);

        [DllImport("glut32.dll")]
        private static extern void glutSolidTorus(double radius, double outerRadius, int nsides, int rings);

        #endregion Private Static Methods

        #region Private Methods

        private void Reshape(int width, int height)
        {
            double aspectRatio = (float)width / height;
            const double FieldOfView = 40.0;

            /* Build projection matrix once. */
            BuildPerspectiveMatrix(FieldOfView, aspectRatio,
                                   1.0, 20.0, /* Znear and Zfar */
                                   myProjectionMatrix);
        }

        #endregion Private Methods

        #endregion Methods
    }
}