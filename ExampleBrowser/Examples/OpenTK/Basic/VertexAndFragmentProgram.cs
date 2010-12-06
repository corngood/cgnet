namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "OpenTK/Basic/02 Vertex And Fragment Program")]
    public class VertexAndFragmentProgram : Example
    {
        #region Fields

        private const string MyFragmentProgramFileName = "Data/C2E2f_passthru.cg";
        private const string MyFragmentProgramName = "C2E2f_passthru";
        private const string MyVertexProgramFileName = "Data/C2E1v_green.cg";
        private const string MyVertexProgramName = "C2E1v_green";

        private CgProfile myCgFragmentProfile;
        private IntPtr myCgFragmentProgram;
        private CgProfile myCgVertexProfile;
        private IntPtr myCgVertexProgram;

        #endregion Fields

        #region Constructors

        public VertexAndFragmentProgram()
            : base("02_vertex_and_fragment_program")
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

            this.CgContext = Cg.CreateContext();
            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.CgContext, ParameterSettingMode.Deferred);

            myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(myCgVertexProfile);

            myCgVertexProgram =
              Cg.CreateProgramFromFile(
                this.CgContext,              /* Cg runtime context */
                ProgramType.Source,                /* Program in human-readable form */
                MyVertexProgramFileName,  /* Name of file containing program */
                myCgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                MyVertexProgramName,      /* Entry function name */
                null);                    /* No extra compiler options */
            CgGL.LoadProgram(myCgVertexProgram);

            myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(myCgFragmentProfile);

            myCgFragmentProgram =
              Cg.CreateProgramFromFile(
                this.CgContext,                /* Cg runtime context */
                ProgramType.Source,                  /* Program in human-readable form */
                MyFragmentProgramFileName,  /* Name of file containing program */
                myCgFragmentProfile,        /* Profile: OpenGL ARB vertex program */
                MyFragmentProgramName,      /* Entry function name */
                null);                      /* No extra compiler options */
            CgGL.LoadProgram(myCgFragmentProgram);
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

            DrawStars();

            CgGL.DisableProfile(myCgVertexProfile);

            CgGL.DisableProfile(myCgFragmentProfile);
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

        #region Private Static Methods

        static void DrawStar(float x, float y, int starPoints, float R, float r)
        {
            int i;
            double piOverStarPoints = 3.14159 / starPoints,
                   angle = 0.0;

            GL.Begin(BeginMode.TriangleFan);
            GL.Vertex2(x, y);  /* Center of star */
            /* Emit exterior vertices for star's points. */
            for (i = 0; i < starPoints; i++)
            {
                GL.Vertex2(x + R * Math.Cos(angle), y + R * Math.Sin(angle));
                angle += piOverStarPoints;
                GL.Vertex2(x + r * Math.Cos(angle), y + r * Math.Sin(angle));
                angle += piOverStarPoints;
            }
            /* End by repeating first exterior vertex of star. */
            angle = 0;
            GL.Vertex2(x + R * Math.Cos(angle), y + R * Math.Sin(angle));
            GL.End();
        }

        static void DrawStars()
        {
            /*                     star    outer   inner  */
            /*        x      y     Points  radius  radius */
            /*       =====  =====  ======  ======  ====== */
            DrawStar(-0.1f, 0, 5, 0.5f, 0.2f);
            DrawStar(-0.84f, 0.1f, 5, 0.3f, 0.12f);
            DrawStar(0.92f, -0.5f, 5, 0.25f, 0.11f);
            DrawStar(0.3f, 0.97f, 5, 0.3f, 0.1f);
            DrawStar(0.94f, 0.3f, 5, 0.5f, 0.2f);
            DrawStar(-0.97f, -0.8f, 5, 0.6f, 0.2f);
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}