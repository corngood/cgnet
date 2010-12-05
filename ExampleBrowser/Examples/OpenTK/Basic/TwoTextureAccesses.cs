namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "OpenTK/Basic/07 Two Texture Accesses")]
    public class TwoTextureAccesses : Example
    {
        #region Fields

        private const string MyFragmentProgramFileName = "Data/C3E6f_twoTextures.cg";
        private const string MyFragmentProgramName = "C3E6f_twoTextures";
        private const string MyVertexProgramFileName = "Data/C3E5v_twoTextures.cg";
        private const string MyVertexProgramName = "C3E5v_twoTextures";

        private IntPtr myCgContext;
        private IntPtr myCgFragmentParamDecal;
        private CgProfile myCgFragmentProfile;
        private IntPtr myCgFragmentProgram;
        private IntPtr myCgVertexParam_leftSeparation, myCgVertexParam_rightSeparation;
        private CgProfile myCgVertexProfile;
        private IntPtr myCgVertexProgram;
        private float mySeparation = 0.1f,
             mySeparationVelocity = 0.005f;

        #endregion Fields

        #region Constructors

        public TwoTextureAccesses()
            : base("07_two_texture_accesses")
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

            GL.TexImage2D<byte>(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb8, 128, 128, 0,
                                PixelFormat.Rgb, PixelType.UnsignedByte, DemonPic.Array);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            this.myCgContext = Cg.CreateContext();
            this.CheckForCgError("creating context");
            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.myCgContext, ParameterSettingMode.Deferred);

            this.myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.myCgVertexProfile);
            this.CheckForCgError("selecting vertex profile");

            this.myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    this.myCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyVertexProgramFileName, /* Name of file containing program */
                    this.myCgVertexProfile,  /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName,      /* Entry function name */
                    null);                    /* No extra compiler options */
            this.CheckForCgError("creating vertex program from file");
            CgGL.LoadProgram(this.myCgVertexProgram);
            this.CheckForCgError("loading vertex program");

            myCgVertexParam_leftSeparation =
             Cg.GetNamedParameter(myCgVertexProgram, "leftSeparation");
            CheckForCgError("could not get leftSeparation parameter");
            myCgVertexParam_rightSeparation =
              Cg.GetNamedParameter(myCgVertexProgram, "rightSeparation");
            CheckForCgError("could not get rightSeparation parameter");

            this.myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(this.myCgFragmentProfile);
            this.CheckForCgError("selecting fragment profile");

            this.myCgFragmentProgram =
                Cg.CreateProgramFromFile(
                    this.myCgContext, /* Cg runtime context */
                    ProgramType.Source,  /* Program in human-readable form */
                    MyFragmentProgramFileName,  /* Name of file containing program */
                    this.myCgFragmentProfile,        /* Profile: OpenGL ARB vertex program */
                    MyFragmentProgramName,      /* Entry function name */
                    null);                      /* No extra compiler options */
            this.CheckForCgError("creating fragment program from file");
            CgGL.LoadProgram(this.myCgFragmentProgram);
            this.CheckForCgError("loading fragment program");

            this.myCgFragmentParamDecal =
                Cg.GetNamedParameter(this.myCgFragmentProgram, "decal");
            this.CheckForCgError("getting decal parameter");

            CgGL.SetTextureParameter(this.myCgFragmentParamDecal, 666);
            this.CheckForCgError("setting decal 2D texture");
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (mySeparation > 0)
            {
                /* Separate in the horizontal direction. */
                Cg.SetParameter(myCgVertexParam_leftSeparation, -mySeparation, 0);
                Cg.SetParameter(myCgVertexParam_rightSeparation, mySeparation, 0);
            }
            else
            {
                /* Separate in the vertical direction. */
                Cg.SetParameter(myCgVertexParam_leftSeparation, 0, -mySeparation);
                Cg.SetParameter(myCgVertexParam_rightSeparation, 0, mySeparation);
            }

            CgGL.BindProgram(this.myCgVertexProgram);
            this.CheckForCgError("binding vertex program");

            CgGL.EnableProfile(this.myCgVertexProfile);
            this.CheckForCgError("enabling vertex profile");

            CgGL.BindProgram(this.myCgFragmentProgram);
            this.CheckForCgError("binding fragment program");

            CgGL.EnableProfile(this.myCgFragmentProfile);
            this.CheckForCgError("enabling fragment profile");

            CgGL.EnableTextureParameter(this.myCgFragmentParamDecal);
            this.CheckForCgError("enable decal texture");

            GL.Begin(BeginMode.Triangles);
            GL.TexCoord2(0, 0);
            GL.Vertex2(-0.8f, 0.8f);

            GL.TexCoord2(1, 0);
            GL.Vertex2(0.8f, 0.8f);

            GL.TexCoord2(0.5f, 1);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            CgGL.DisableProfile(this.myCgVertexProfile);
            this.CheckForCgError("disabling vertex profile");

            CgGL.DisableProfile(this.myCgFragmentProfile);
            this.CheckForCgError("disabling fragment profile");

            CgGL.DisableTextureParameter(this.myCgFragmentParamDecal);
            this.CheckForCgError("disabling decal texture");

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

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            Cg.DestroyProgram(this.myCgVertexProgram);
            Cg.DestroyProgram(this.myCgFragmentProgram);
            Cg.DestroyContext(this.myCgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (mySeparation > 0.4f)
            {
                mySeparationVelocity = -0.005f;
            }
            else if (mySeparation < -0.4f)
            {
                mySeparationVelocity = 0.005f;
            }
            mySeparation += mySeparationVelocity;

            if (this.Keyboard[Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #endregion Methods
    }
}