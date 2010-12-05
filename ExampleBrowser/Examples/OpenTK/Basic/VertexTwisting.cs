namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;
    using System.Windows.Forms;

    using CgNet;
    using CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "OpenTK/Basic/06 Vertex Twisting")]
    public class VertexTwisting : Example
    {
        #region Fields

        public IntPtr myCgVertexParam_twisting;

        private const string MyFragmentProgramFileName = "Data/C2E2f_passthru.cg";
        private const string MyFragmentProgramName = "C2E2f_passthru";
        private const string MyVertexProgramFileName = "Data/C3E4v_twist.cg";
        private const string MyVertexProgramName = "C3E4v_twist";

        private IntPtr myCgContext;
        private CgProfile myCgFragmentProfile;
        private IntPtr myCgFragmentProgram;
        private CgProfile myCgVertexProfile;
        private IntPtr myCgVertexProgram;
        private float myTwisting = 2.9f, /* Twisting angle in radians. */
             myTwistDirection = 0.1f; /* Animation delta for twist. */
        private bool wireframe;

        #endregion Fields

        #region Constructors

        public VertexTwisting()
            : base("06_vertex_twisting")
        {
        }

        #endregion Constructors

        #region Methods

        #region Protected Methods

        protected override void OnKeyPress(global::OpenTK.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                wireframe = !wireframe;
                if (wireframe)
                {
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                }
                else
                {
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                }
            }
        }

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f);  /* Blue background */

            this.myCgContext = Cg.CreateContext();
            this.CheckForCgError("creating context");
            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.myCgContext, ParameterSettingMode.Deferred);

            this.myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.myCgVertexProfile);
            this.CheckForCgError("selecting vertex profile");

            this.myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    this.myCgContext,              /* Cg runtime context */
                    ProgramType.Source,                /* Program in human-readable form */
                    MyVertexProgramFileName,  /* Name of file containing program */
                    this.myCgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName,      /* Entry function name */
                    null);                    /* No extra compiler options */
            this.CheckForCgError("creating vertex program from file");
            CgGL.LoadProgram(this.myCgVertexProgram);
            this.CheckForCgError("loading vertex program");

            myCgVertexParam_twisting = Cg.GetNamedParameter(myCgVertexProgram, "twisting");
            CheckForCgError("could not get twisting parameter");

            this.myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(this.myCgFragmentProfile);
            this.CheckForCgError("selecting fragment profile");

            this.myCgFragmentProgram =
                Cg.CreateProgramFromFile(
                    this.myCgContext,                /* Cg runtime context */
                    ProgramType.Source,                  /* Program in human-readable form */
                    MyFragmentProgramFileName,  /* Name of file containing program */
                    this.myCgFragmentProfile,        /* Profile: OpenGL ARB vertex program */
                    MyFragmentProgramName,      /* Entry function name */
                    null);                      /* No extra compiler options */
            this.CheckForCgError("creating fragment program from file");
            CgGL.LoadProgram(this.myCgFragmentProgram);
            this.CheckForCgError("loading fragment program");
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Cg.SetParameter(myCgVertexParam_twisting, myTwisting);

            CgGL.BindProgram(this.myCgVertexProgram);
            this.CheckForCgError("binding vertex program");

            CgGL.EnableProfile(this.myCgVertexProfile);
            this.CheckForCgError("enabling vertex profile");

            CgGL.BindProgram(this.myCgFragmentProgram);
            this.CheckForCgError("binding fragment program");

            CgGL.EnableProfile(this.myCgFragmentProfile);
            this.CheckForCgError("enabling fragment profile");

            DrawSubDividedTriangle(5);

            CgGL.DisableProfile(this.myCgVertexProfile);
            this.CheckForCgError("disabling vertex profile");

            CgGL.DisableProfile(this.myCgFragmentProfile);
            this.CheckForCgError("disabling fragment profile");
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
            Twist();
            if (this.Keyboard[Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #region Private Static Methods

        private static void TriangleDivide(int depth, float[] a, float[] b, float[] c, float[] ca, float[] cb, float[] cc)
        {
            if (depth == 0)
            {
                GL.Color3(ca);
                GL.Vertex2(a);
                GL.Color3(cb);
                GL.Vertex2(b);
                GL.Color3(cc);
                GL.Vertex2(c);
            }
            else
            {
                float[] d = { (a[0] + b[0]) / 2, (a[1] + b[1]) / 2 },
                            e = { (b[0] + c[0]) / 2, (b[1] + c[1]) / 2 },
                            f = { (c[0] + a[0]) / 2, (c[1] + a[1]) / 2 };
                float[] cd = { (ca[0] + cb[0]) / 2, (ca[1] + cb[1]) / 2, (ca[2] + cb[2]) / 2 },
                            ce = { (cb[0] + cc[0]) / 2, (cb[1] + cc[1]) / 2, (cb[2] + cc[2]) / 2 },
                            cf = { (cc[0] + ca[0]) / 2, (cc[1] + ca[1]) / 2, (cc[2] + ca[2]) / 2 };

                depth -= 1;
                TriangleDivide(depth, a, d, f, ca, cd, cf);
                TriangleDivide(depth, d, b, e, cd, cb, ce);
                TriangleDivide(depth, f, e, c, cf, ce, cc);
                TriangleDivide(depth, d, e, f, cd, ce, cf);
            }
        }

        #endregion Private Static Methods

        #region Private Methods

        /* Large vertex displacements such as are possible with C3E4v_twist
           require a high degree of tessellation.  This routine draws a
           triangle recursively subdivided to provide sufficient tessellation. */
        private void DrawSubDividedTriangle(int subdivisions)
        {
            float[] a = { -0.8f, 0.8f },
                       b = { 0.8f, 0.8f },
                       c = { 0.0f, -0.8f },
                       ca = { 0, 0, 1 },
                       cb = { 0, 0, 1 },
                       cc = { 0.7f, 0.7f, 1 };

            GL.Begin(BeginMode.Triangles);
            TriangleDivide(subdivisions, a, b, c, ca, cb, cc);
            GL.End();
        }

        private void Twist()
        {
            if (myTwisting > 3)
            {
                myTwistDirection = -0.05f;
            }
            else if (myTwisting < -3)
            {
                myTwistDirection = 0.05f;
            }
            myTwisting += myTwistDirection;
        }

        #endregion Private Methods

        #endregion Methods
    }
}