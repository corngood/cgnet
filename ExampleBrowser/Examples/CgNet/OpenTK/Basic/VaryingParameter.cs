namespace ExampleBrowser.Examples.CgNet.OpenTK.Basic
{
    using System;

    using ExampleBrowser.Examples.CgNet.OpenTK;

    using global::CgNet;
    using global::CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "CgNet/OpenTK/Basic/04 Varying Parameter")]
    public class VaryingParameter : Example
    {
        #region Fields

        private const string MyFragmentProgramFileName = "Data/C2E2f_passthru.cg";
        private const string MyFragmentProgramName = "C2E2f_passthru";
        private const string MyVertexProgramFileName = "Data/C3E2v_varying.cg";
        private const string MyVertexProgramName = "C3E2v_varying";

        private ProfileType myCgFragmentProfile;
        private IntPtr myCgFragmentProgram;
        private ProfileType myCgVertexProfile;
        private IntPtr myCgVertexProgram;

        #endregion Fields

        #region Constructors

        public VaryingParameter()
            : base("04_varying_parameter")
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

            this.myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(this.myCgFragmentProfile);

            this.myCgFragmentProgram =
                Cg.CreateProgramFromFile(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyFragmentProgramFileName, /* Name of file containing program */
                    this.myCgFragmentProfile, /* Profile: OpenGL ARB vertex program */
                    MyFragmentProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            CgGL.LoadProgram(this.myCgFragmentProgram);
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

            CgGL.EnableProfile(this.myCgVertexProfile);

            CgGL.BindProgram(this.myCgFragmentProgram);

            CgGL.EnableProfile(this.myCgFragmentProfile);

            GL.Begin(BeginMode.Triangles);
            GL.Color3(1f, 0f, 0f); /* Red */
            GL.Vertex2(-0.8f, 0.8f);

            GL.Color3(0f, 1f, 0f); /* Green */
            GL.Vertex2(0.8f, 0.8f);

            GL.Color3(0f, 0f, 1f); /* Blue */
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            CgGL.DisableProfile(this.myCgVertexProfile);

            CgGL.DisableProfile(this.myCgFragmentProfile);
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
            Cg.DestroyContext(this.MyCgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}