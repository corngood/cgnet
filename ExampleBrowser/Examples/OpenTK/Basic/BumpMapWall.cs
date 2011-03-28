namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;
    using System.Runtime.InteropServices;

    using All = global::OpenTK.Graphics.OpenGL.All;

    using BeginMode = global::OpenTK.Graphics.OpenGL.BeginMode;

    using ClearBufferMask = global::OpenTK.Graphics.OpenGL.ClearBufferMask;

    using EnableCap = global::OpenTK.Graphics.OpenGL.EnableCap;

    using ExampleBrowser.Examples.OpenTK;

    using GL = global::OpenTK.Graphics.OpenGL.GL;

    using global::CgNet;
    using global::CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics;
    using global::OpenTK.Input;

    using MatrixMode = global::OpenTK.Graphics.OpenGL.MatrixMode;

    using PixelFormat = global::OpenTK.Graphics.OpenGL.PixelFormat;

    using PixelInternalFormat = global::OpenTK.Graphics.OpenGL.PixelInternalFormat;

    using PixelStoreParameter = global::OpenTK.Graphics.OpenGL.PixelStoreParameter;

    using PixelType = global::OpenTK.Graphics.OpenGL.PixelType;

    using TextureParameterName = global::OpenTK.Graphics.OpenGL.TextureParameterName;

    using TextureTarget = global::OpenTK.Graphics.OpenGL.TextureTarget;

    [Example(NodePath = "OpenTK/Basic/21 Bump Map Wall")]
    public class BumpMapWall : Example
    {
        #region Fields

        private const string MyFragmentProgramFileName = "Data/C8E2f_bumpSurf.cg";
        private const string MyFragmentProgramName = "C8E2f_bumpSurf";
        private const string MyVertexProgramFileName = "Data/C8E1v_bumpWall.cg";
        private const string MyVertexProgramName = "C8E1v_bumpWall";

        private readonly int[] texObj = new int[2];

        private float my2Pi = 2.0f * 3.14159265358979323846f;
        private Parameter fragmentParamNormalizeCube;
        private Parameter fragmentParamNormalMap;
        private ProfileType fragmentProfile;
        private Program fragmentProgram;
        private Parameter vertexParamLightPosition;
        private Parameter vertexParamModelViewProj;
        private ProfileType vertexProfile;
        private Program vertexProgram;
        private float myLightAngle = 4.0f; /* Angle light rotates around scene. */

        #endregion Fields

        #region Constructors

        public BumpMapWall()
            : base("21_bump_map_wall")
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
            GL.Enable(EnableCap.Texture2D);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1); /* Tightly packed texture data. */

            GL.GenTextures(2, texObj);

            GL.BindTexture(TextureTarget.Texture2D, texObj[1]);
            /* Load each mipmap level of range-compressed 128x128 brick normal
               map texture. */
            unsafe
            {
                fixed (byte* b = BrickImage.Array)
                {
                    byte* image = b;

                    int size;
                    int level;
                    for (size = 128, level = 0;
                         size > 0;
                         image += 3 * size * size, size /= 2, level++)
                    {
                        GL.TexImage2D(TextureTarget.Texture2D, level,
                                      PixelInternalFormat.Rgba8, size, size, 0,
                                      PixelFormat.Rgb, PixelType.UnsignedByte, new IntPtr(image));
                    }
                }
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.LinearMipmapLinear);

            GL.BindTexture(TextureTarget.TextureCubeMap, texObj[0]);
            /* Load each 32x32 face (without mipmaps) of range-compressed "normalize
               vector" cube map. */
            unsafe
            {
                fixed (byte* b = NormcmImage.Array)
                {
                    byte* image = b;

                    int face;
                    for (face = 0;
                         face < 6;
                         face++, image += 3 * 32 * 32)
                    {
                        GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + face, 0,
                                      PixelInternalFormat.Rgba8, 32, 32, 0,
                                      PixelFormat.Rgb, PixelType.UnsignedByte, new IntPtr(image));
                    }
                }
            }

            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)All.ClampToEdge);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)All.ClampToEdge);

            this.CgContext = CgNet.Context.Create();
            CgGL.SetDebugMode(false);
            this.CgContext.ParameterSettingMode = ParameterSettingMode.Deferred;

            this.vertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.vertexProfile);

            this.vertexProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    MyVertexProgramFileName, /* Name of file containing program */
                    this.vertexProfile, /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            this.vertexProgram.Load();

            this.vertexParamLightPosition =
                vertexProgram.GetNamedParameter("lightPosition");

            this.vertexParamModelViewProj =
                vertexProgram.GetNamedParameter("modelViewProj");

            this.fragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(this.fragmentProfile);

            this.fragmentProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    MyFragmentProgramFileName, /* Name of file containing program */
                    this.fragmentProfile, /* Profile: OpenGL ARB vertex program */
                    MyFragmentProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            this.fragmentProgram.Load();

            this.fragmentParamNormalMap =
                fragmentProgram.GetNamedParameter("normalMap");

            this.fragmentParamNormalizeCube =
                fragmentProgram.GetNamedParameter("normalizeCube");

            this.fragmentParamNormalMap.SetTexture(texObj[1]);

            this.fragmentParamNormalizeCube.SetTexture(texObj[0]);
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            float[] lightPosition = {
                                        12.5f * (float)Math.Sin(this.myLightAngle),
                                        12.5f * (float)Math.Cos(this.myLightAngle),
                                        4
                                    };

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            Glu.LookAt(
                0.0, 0.0, 20.0,
                0.0, 0.0, 0.0, /* XYZ view center */
                0.0, 1.0, 0.0); /* Up is in positive Y direction */

            vertexProgram.Bind();

            this.vertexParamModelViewProj.SetStateMatrix(MatrixType.ModelviewProjectionMatrix, MatrixTransform.MatrixIdentity);

            this.vertexParamLightPosition.Set(lightPosition);

            CgGL.EnableProfile(vertexProfile);

            fragmentProgram.Bind();

            this.fragmentParamNormalMap.Enable();
            this.fragmentParamNormalizeCube.Enable();

            CgGL.EnableProfile(fragmentProfile);

            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();

            GL.Begin(BeginMode.Quads);
            /* Counter clockwise (GL_CCW) winding */
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(-7f, -7f);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(7f, -7f);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(7f, 7f);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(-7f, 7f);
            GL.End();

            CgGL.DisableProfile(vertexProfile);

            CgGL.DisableProfile(fragmentProfile);

            /*** Render light as white ball using fixed function pipe ***/

            GL.Translate(lightPosition[0], lightPosition[1], lightPosition[2]);
            GL.Color3(0.8f, 0.8f, 0.1f); /* yellow */
            glutSolidSphere(0.4, 12, 12);

            this.SwapBuffers();
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            double aspectRatio = (float)this.Width / this.Height;
            double fieldOfView = 75.0; /* Degrees */

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Glu.Perspective(fieldOfView, aspectRatio,
                            0.1, /* Z near */
                            100.0); /* Z far */
            GL.MatrixMode(MatrixMode.Modelview);

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
            this.myLightAngle += 0.008f; /* Add a small angle (in radians). */
            if (this.myLightAngle > my2Pi)
            {
                this.myLightAngle -= my2Pi;
            }

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        [DllImport("glut32.dll")]
        private static extern void glutSolidSphere(double radius, int slices, int stacks);

        #endregion Private Static Methods

        #endregion Methods
    }
}