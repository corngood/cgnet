namespace Examples
{
    using System;

    using CGNet;
    using CGNet.GL;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public class VertexProgram : GameWindow
    {
        #region Fields

        private const string MyProgramName = "01_vertex_program";
        private const string MyVertexProgramFileName = "C2E1v_green.cg";
        private const string MyVertexProgramName = "C2E1v_green";

        private int myCgVertexProfile;
        private IntPtr myCgVertexProgram;

        #endregion Fields

        #region Constructors

        public VertexProgram()
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
            using (var example = new VertexProgram())
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

            var myCgContext = Cg.CreateContext();
            //Cg.cgCheckForCgError("creating context");
            //    cgGLSetDebugMode(CG_FALSE);
            Cg.SetParameterSettingMode(myCgContext, ParameterSettingMode.Deferred);

            this.myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(myCgVertexProfile);
            //    checkForCgError("selecting vertex profile");

            this.myCgVertexProgram =
              Cg.CreateProgramFromFile(
                myCgContext,              /* Cg runtime context */
                ProgramType.Source,                /* Program in human-readable form */
                MyVertexProgramFileName,  /* Name of file containing program */
                myCgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                MyVertexProgramName,      /* Entry function name */
                null);                    /* No extra compiler options */
            //checkForCgError("creating vertex program from file");
            CgGL.LoadProgram(myCgVertexProgram);
            //    checkForCgError("loading vertex program");
            //
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            CgGL.BindProgram(this.myCgVertexProgram);
            //checkForCgError("binding vertex program");

            CgGL.EnableProfile(this.myCgVertexProfile);
            //checkForCgError("enabling vertex profile");

            /* Rendering code verbatim from Chapter 1, Section 2.4.1 "Rendering
               a Triangle with OpenGL" (page 57). */
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(-0.8f, 0.8f);
            GL.Vertex2(0.8f, 0.8f);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            CgGL.DisableProfile(this.myCgVertexProfile);
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