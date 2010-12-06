namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "OpenTK/Basic/05 Texture Sampling")]
    public class TextureSampling : Example
    {
        #region Fields

        private const string MyFragmentProgramFileName = "Data/C3E3f_texture.cg";
        private const string MyFragmentProgramName = "C3E3f_texture";
        private const string MyVertexProgramFileName = "Data/C3E2v_varying.cg";
        private const string MyVertexProgramName = "C3E2v_varying";

        private IntPtr myCgFragmentParamDecal;
        private CgProfile myCgFragmentProfile;
        private IntPtr myCgFragmentProgram;
        private CgProfile myCgVertexProfile;
        private IntPtr myCgVertexProgram;

        #endregion Fields

        #region Constructors

        public TextureSampling()
            : base("05_texture_sampling")
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
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f);  /* Blue background */

            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1); /* Tightly packed texture data. */
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, 666);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb8, 128, 128, 0,
                PixelFormat.Rgb, PixelType.UnsignedByte, DemonPic.Array);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            this.CgContext = Cg.CreateContext();

            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.CgContext, ParameterSettingMode.Deferred);

            myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(myCgVertexProfile);

            myCgVertexProgram =
                Cg.CreateProgramFromFile(
                this.CgContext, /* Cg runtime context */
                ProgramType.Source, /* Program in human-readable form */
                MyVertexProgramFileName, /* Name of file containing program */
                myCgVertexProfile,  /* Profile: OpenGL ARB vertex program */
                MyVertexProgramName,      /* Entry function name */
                null);                    /* No extra compiler options */

            CgGL.LoadProgram(myCgVertexProgram);

            /* No uniform vertex program parameters expected. */
            myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(myCgFragmentProfile);

            myCgFragmentProgram =
                Cg.CreateProgramFromFile(
                this.CgContext, /* Cg runtime context */
                ProgramType.Source,  /* Program in human-readable form */
                MyFragmentProgramFileName,  /* Name of file containing program */
                myCgFragmentProfile,        /* Profile: OpenGL ARB vertex program */
                MyFragmentProgramName,      /* Entry function name */
                null);                      /* No extra compiler options */

            CgGL.LoadProgram(myCgFragmentProgram);

            this.myCgFragmentParamDecal = Cg.GetNamedParameter(myCgFragmentProgram, "decal");

            CgGL.SetTextureParameter(this.myCgFragmentParamDecal, 666);
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            CgGL.BindProgram(myCgVertexProgram);

            CgGL.EnableProfile(myCgVertexProfile);

            CgGL.BindProgram(myCgFragmentProgram);

            CgGL.EnableProfile(myCgFragmentProfile);

            CgGL.EnableTextureParameter(this.myCgFragmentParamDecal);

            GL.Begin(BeginMode.Triangles);
            GL.TexCoord2(0, 0);
            GL.Vertex2(-0.8f, 0.8f);

            GL.TexCoord2(1, 0);
            GL.Vertex2(0.8f, 0.8f);

            GL.TexCoord2(0.5f, 1);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            CgGL.DisableProfile(myCgVertexProfile);

            CgGL.DisableProfile(myCgFragmentProfile);

            CgGL.DisableTextureParameter(this.myCgFragmentParamDecal);

            SwapBuffers();
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            Cg.DestroyProgram(myCgVertexProgram);
            Cg.DestroyProgram(myCgFragmentProgram);
            Cg.DestroyContext(this.CgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (Keyboard[Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #endregion Methods
    }
}