namespace ExampleBrowser.Examples.CgOO.OpenTK.Basic
{
    using System;

    using global::CgNet;
    using global::CgNet.GL;

    using global::CgOO;
    using global::CgOO.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "CgOO/OpenTK/Basic/01 Vertex Program")]
    public class VertexProgram : Example
    {
        #region Fields

        private const string VertexProgramFileName = "Data/C2E1v_green.cg";
        private const string VertexProgramName = "C2E1v_green";

        private ProfileType cgVertexProfile;
        private CgProgram cgVertexProgram;

        #endregion Fields

        #region Constructors

        public VertexProgram()
            : base("01_vertex_program")
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

            this.CgContext = CgContext.Create();

            CgGL.SetDebugMode(false);
            this.CgContext.ParameterSettingMode = ParameterSettingMode.Deferred;

            this.cgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.cgVertexProfile);

            this.cgVertexProgram =
                CgContext.CreateProgramFromFile(
                    ProgramType.Source,                /* Program in human-readable form */
                    VertexProgramFileName,  /* Name of file containing program */
                    this.cgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                    VertexProgramName,      /* Entry function name */
                    null);                    /* No extra compiler options */

            CgGL.LoadProgram(this.cgVertexProgram.Handle);
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            this.cgVertexProgram.BindProgram();

            CgGL.EnableProfile(this.cgVertexProfile);

            /* Rendering code verbatim from Chapter 1, Section 2.4.1 "Rendering
               a Triangle with OpenGL" (page 57). */
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(-0.8f, 0.8f);
            GL.Vertex2(0.8f, 0.8f);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            CgGL.DisableProfile(this.cgVertexProfile);
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
            this.cgVertexProgram.Dispose();
            this.CgContext.Dispose();
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (this.Keyboard[Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #endregion Methods
    }
}