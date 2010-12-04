namespace Examples
{
    using System;

    using CGNet;
    using CGNet.GL;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public class VertexAndFragmentProgram : GameWindow
    {
        #region Fields

        private const string MyProgramName = "02_vertex_and_fragment_program";
        private IntPtr myCgContext;
        private int myCgVertexProfile;
        private int myCgFragmentProfile;
        private IntPtr myCgVertexProgram;
        private IntPtr myCgFragmentProgram;

        private const string myVertexProgramFileName = "C2E1v_green.cg";
        private const string myVertexProgramName = "C2E1v_green";
        private const string myFragmentProgramFileName = "C2E2f_passthru.cg";
        private const string myFragmentProgramName = "C2E2f_passthru";

        #endregion Fields

        #region Constructors

        public VertexAndFragmentProgram()
            : base(800, 600)
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Entry point of this example.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var example = new VertexAndFragmentProgram())
            {
                example.Title = MyProgramName;
                example.Run(30.0, 0.0);
            }
        }

        #endregion Public Static Methods

        #region Protected Methods

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f);  /* Blue background */

            myCgContext = Cg.CreateContext();
            //checkForCgError("creating context");
            //cgGLSetDebugMode(CG_FALSE);
            Cg.SetParameterSettingMode(myCgContext, ParameterSettingMode.Deferred);

            myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(myCgVertexProfile);
            //checkForCgError("selecting vertex profile");

            myCgVertexProgram =
              Cg.CreateProgramFromFile(
                myCgContext,              /* Cg runtime context */
                ProgramType.Source,                /* Program in human-readable form */
                myVertexProgramFileName,  /* Name of file containing program */
                myCgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                myVertexProgramName,      /* Entry function name */
                null);                    /* No extra compiler options */
            //checkForCgError("creating vertex program from file");
            CgGL.LoadProgram(myCgVertexProgram);
            //checkForCgError("loading vertex program");

            myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(myCgFragmentProfile);
            //checkForCgError("selecting fragment profile");

            myCgFragmentProgram =
              Cg.CreateProgramFromFile(
                myCgContext,                /* Cg runtime context */
                ProgramType.Source,                  /* Program in human-readable form */
                myFragmentProgramFileName,  /* Name of file containing program */
                myCgFragmentProfile,        /* Profile: OpenGL ARB vertex program */
                myFragmentProgramName,      /* Entry function name */
                null);                      /* No extra compiler options */
            //checkForCgError("creating fragment program from file");
            CgGL.LoadProgram(myCgFragmentProgram);
            //checkForCgError("loading fragment program");
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
            //checkForCgError("binding vertex program");

            CgGL.EnableProfile(myCgVertexProfile);
            //checkForCgError("enabling vertex profile");

            CgGL.BindProgram(myCgFragmentProgram);
            //checkForCgError("binding fragment program");

            CgGL.EnableProfile(myCgFragmentProfile);
            //checkForCgError("enabling fragment profile");

            DrawStars();

            CgGL.DisableProfile(myCgVertexProfile);
            //checkForCgError("disabling vertex profile");

            CgGL.DisableProfile(myCgFragmentProfile);
            //checkForCgError("disabling fragment profile");
            SwapBuffers();
        }

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

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (Keyboard[OpenTK.Input.Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #endregion Methods
    }
}