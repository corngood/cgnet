namespace ExampleBrowser.Examples.CgNet.OpenTK.Basic
{
    using System;
    using System.Runtime.InteropServices;

    using ExampleBrowser.Examples.CgNet.OpenTK;

    using global::CgNet;
    using global::CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "CgNet/OpenTK/Basic/08 Vertex Transform")]
    public class VertexTransform : Example
    {
        #region Fields

        private const string MyVertexProgramFileName = "Data/C4E1v_transform.cg";
        private const string MyVertexProgramName = "C4E1v_transform";

        private static readonly float[] MyProjectionMatrix = new float[16];

        private static float myEyeAngle; /* Angle eye rotates around scene. */

        private IntPtr myCgVertexParamModelViewProj, myCgFragmentParamC;
        private ProfileType myCgVertexProfile, myCgFragmentProfile;
        private IntPtr myCgVertexProgram, myCgFragmentProgram;

        #endregion Fields

        #region Constructors

        public VertexTransform()
            : base("08_vertex_transform")
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

            this.myCgVertexParamModelViewProj =
                Cg.GetNamedParameter(myCgVertexProgram, "modelViewProj");

            myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(myCgFragmentProfile);

            /* Specify fragment program with a string. */
            myCgFragmentProgram =
                Cg.CreateProgram(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    "float4 main(uniform float4 c) : COLOR { return c; }",
                    myCgFragmentProfile, /* Profile: latest fragment profile */
                    "main", /* Entry function name */
                    null); /* No extra compiler options */
            CgGL.LoadProgram(myCgFragmentProgram);

            this.myCgFragmentParamC =
                Cg.GetNamedParameter(myCgFragmentProgram, "c");
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            float[] viewMatrix = new float[16];
            BuildLookAtMatrix(13 * Math.Sin(myEyeAngle), 0, 13 * Math.Cos(myEyeAngle), /* eye position */
                              0, 0, 0, /* view center */
                              0, 1, 0, /* up vector */
                              viewMatrix);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            CgGL.BindProgram(this.myCgVertexProgram);

            CgGL.EnableProfile(this.myCgVertexProfile);

            CgGL.BindProgram(this.myCgFragmentProgram);

            CgGL.EnableProfile(this.myCgFragmentProfile);

            /* modelView = rotateMatrix * translateMatrix */
            float[] rotateMatrix = new float[16];
            float[] translateMatrix = new float[16];
            float[] modelMatrix = new float[16];
            float[] modelViewMatrix = new float[16];
            float[] modelViewProjMatrix = new float[16];

            MakeRotateMatrix(70, 1, 1, 1, rotateMatrix);
            MakeTranslateMatrix(2, 0, 0, translateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, MyProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.SetMatrixParameter(this.myCgVertexParamModelViewProj, modelViewProjMatrix);
            Cg.SetParameter(this.myCgFragmentParamC, 0.1f, 0.7f, 0.1f, 1f); /* Green */
            Cg.UpdateProgramParameters(myCgVertexProgram);
            Cg.UpdateProgramParameters(myCgFragmentProgram);
            glutWireSphere(2.0, 30, 30);

            /*** Render red wireframe cone ***/
            MakeTranslateMatrix(-2, -1.5f, 0, translateMatrix);
            MakeRotateMatrix(90, 1, 0, 0, rotateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, MyProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.SetMatrixParameter(this.myCgVertexParamModelViewProj, modelViewProjMatrix);
            Cg.SetParameter(this.myCgFragmentParamC, 0.8f, 0.1f, 0.1f, 1); /* Red */
            Cg.UpdateProgramParameters(myCgVertexProgram);
            Cg.UpdateProgramParameters(myCgFragmentProgram);
            glutWireCone(1.5, 3.5, 20, 20);

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

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
            Reshape(this.Width, this.Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            Cg.DestroyProgram(this.myCgVertexProgram);
            Cg.DestroyContext(this.MyCgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            myEyeAngle += 0.008f; /* Add a small angle (in radians). */
            if (myEyeAngle > 2 * MyPi)
            {
                myEyeAngle -= (float)(2 * MyPi);
            }

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        /* Build a row-major (C-style) 4x4 matrix transform based on the
           parameters for gluLookAt. */
        [DllImport("glut32.dll")]
        private static extern void glutWireCone(double bse, double height, int slices, int stacks);

        [DllImport("glut32.dll")]
        private static extern void glutWireSphere(double radius, int slices, int stacks);

        private static void Reshape(int width, int height)
        {
            double aspectRatio = (float)width / height;
            const double FieldOfView = 40.0;

            /* Build projection matrix once. */
            BuildPerspectiveMatrix(FieldOfView, aspectRatio,
                                   1.0, 20.0, /* Znear and Zfar */
                                   MyProjectionMatrix);
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}