namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;
    using System.Runtime.InteropServices;

    using CgNet;
    using CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "OpenTK/Basic/08 Vertex Transform")]
    public class VertexTransform : Example
    {
        #region Fields

        const double MyPi = 3.14159265358979323846;
        private const string MyVertexProgramFileName = "Data/C4E1v_transform.cg";
        private const string MyVertexProgramName = "C4E1v_transform";

        static readonly float[] MyProjectionMatrix = new float[16];

        static float myEyeAngle; /* Angle eye rotates around scene. */

        private IntPtr myCgVertexParamModelViewProj, myCgFragmentParamC;
        private CgProfile myCgVertexProfile, myCgFragmentProfile;
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
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f);  /* Blue background */

            this.CgContext = Cg.CreateContext();
            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.CgContext, ParameterSettingMode.Deferred);

            this.myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(this.myCgVertexProfile);

            this.myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    this.CgContext,              /* Cg runtime context */
                    ProgramType.Source,                /* Program in human-readable form */
                    MyVertexProgramFileName,  /* Name of file containing program */
                    this.myCgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName,      /* Entry function name */
                    null);                    /* No extra compiler options */
            CgGL.LoadProgram(this.myCgVertexProgram);

            this.myCgVertexParamModelViewProj =
              Cg.GetNamedParameter(myCgVertexProgram, "modelViewProj");

            myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(myCgFragmentProfile);

            /* Specify fragment program with a string. */
            myCgFragmentProgram =
              Cg.CreateProgram(
                this.CgContext,              /* Cg runtime context */
                ProgramType.Source,                /* Program in human-readable form */
                "float4 main(uniform float4 c) : COLOR { return c; }",
                myCgFragmentProfile,      /* Profile: latest fragment profile */
                "main",                   /* Entry function name */
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
            BuildLookAtMatrix(13 * Math.Sin(myEyeAngle), 0, 13 * Math.Cos(myEyeAngle),  /* eye position */
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
            Cg.SetParameter(this.myCgFragmentParamC, 0.1f, 0.7f, 0.1f, 1f);  /* Green */
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
            Cg.SetParameter(this.myCgFragmentParamC, 0.8f, 0.1f, 0.1f, 1);  /* Red */
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
            Cg.DestroyContext(this.CgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            myEyeAngle += 0.008f;  /* Add a small angle (in radians). */
            if (myEyeAngle > 2 * MyPi)
            {
                myEyeAngle -= (float)(2 * MyPi);
            }

            if (this.Keyboard[Key.Escape])
                this.Exit();
        }

        #endregion Protected Methods

        #region Private Static Methods

        /* Build a row-major (C-style) 4x4 matrix transform based on the
           parameters for gluLookAt. */
        static void BuildLookAtMatrix(double eyex, double eyey, double eyez,
            double centerx, double centery, double centerz,
            double upx, double upy, double upz,
            float[] m)
        {
            double[] x = new double[3], y = new double[3], z = new double[3];

            /* Difference eye and center vectors to make Z vector. */
            z[0] = eyex - centerx;
            z[1] = eyey - centery;
            z[2] = eyez - centerz;
            /* Normalize Z. */
            double mag = Math.Sqrt(z[0] * z[0] + z[1] * z[1] + z[2] * z[2]);
            if (mag != 0)
            {
                z[0] /= mag;
                z[1] /= mag;
                z[2] /= mag;
            }

            /* Up vector makes Y vector. */
            y[0] = upx;
            y[1] = upy;
            y[2] = upz;

            /* X vector = Y cross Z. */
            x[0] = y[1] * z[2] - y[2] * z[1];
            x[1] = -y[0] * z[2] + y[2] * z[0];
            x[2] = y[0] * z[1] - y[1] * z[0];

            /* Recompute Y = Z cross X. */
            y[0] = z[1] * x[2] - z[2] * x[1];
            y[1] = -z[0] * x[2] + z[2] * x[0];
            y[2] = z[0] * x[1] - z[1] * x[0];

            /* Normalize X. */
            mag = Math.Sqrt(x[0] * x[0] + x[1] * x[1] + x[2] * x[2]);
            if (mag != 0)
            {
                x[0] /= mag;
                x[1] /= mag;
                x[2] /= mag;
            }

            /* Normalize Y. */
            mag = Math.Sqrt(y[0] * y[0] + y[1] * y[1] + y[2] * y[2]);
            if (mag != 0)
            {
                y[0] /= mag;
                y[1] /= mag;
                y[2] /= mag;
            }

            /* Build resulting view matrix. */
            m[0 * 4 + 0] = (float)x[0]; m[0 * 4 + 1] = (float)x[1];
            m[0 * 4 + 2] = (float)x[2]; m[0 * 4 + 3] = (float)(-x[0] * eyex + -x[1] * eyey + -x[2] * eyez);

            m[1 * 4 + 0] = (float)y[0]; m[1 * 4 + 1] = (float)y[1];
            m[1 * 4 + 2] = (float)y[2]; m[1 * 4 + 3] = (float)(-y[0] * eyex + -y[1] * eyey + -y[2] * eyez);

            m[2 * 4 + 0] = (float)z[0]; m[2 * 4 + 1] = (float)z[1];
            m[2 * 4 + 2] = (float)z[2]; m[2 * 4 + 3] = (float)(-z[0] * eyex + -z[1] * eyey + -z[2] * eyez);

            m[3 * 4 + 0] = 0.0f; m[3 * 4 + 1] = 0.0f; m[3 * 4 + 2] = 0.0f; m[3 * 4 + 3] = 1.0f;
        }

        static void BuildPerspectiveMatrix(double fieldOfView,
            double aspectRatio,
            double zNear, double zFar,
            float[] m)
        {
            double radians = fieldOfView / 2.0 * MyPi / 180.0;

            double deltaZ = zFar - zNear;
            double sine = Math.Sin(radians);
            /* Should be non-zero to avoid division by zero. */

            double cotangent = Math.Cos(radians) / sine;

            m[0 * 4 + 0] = (float)(cotangent / aspectRatio);
            m[0 * 4 + 1] = 0.0f;
            m[0 * 4 + 2] = 0.0f;
            m[0 * 4 + 3] = 0.0f;

            m[1 * 4 + 0] = 0.0f;
            m[1 * 4 + 1] = (float)cotangent;
            m[1 * 4 + 2] = 0.0f;
            m[1 * 4 + 3] = 0.0f;

            m[2 * 4 + 0] = 0.0f;
            m[2 * 4 + 1] = 0.0f;
            m[2 * 4 + 2] = (float)(-(zFar + zNear) / deltaZ);
            m[2 * 4 + 3] = (float)(-2 * zNear * zFar / deltaZ);

            m[3 * 4 + 0] = 0.0f;
            m[3 * 4 + 1] = 0.0f;
            m[3 * 4 + 2] = -1;
            m[3 * 4 + 3] = 0;
        }

        [DllImport("glut32.dll")]
        static extern void glutWireCone(double bse, double height, int slices, int stacks);

        [DllImport("glut32.dll")]
        static extern void glutWireSphere(double radius, int slices, int stacks);

        static void MakeRotateMatrix(float angle,
            float ax, float ay, float az,
            float[] m)
        {
            float[] axis = new float[3];

            axis[0] = ax;
            axis[1] = ay;
            axis[2] = az;
            float mag = (float)Math.Sqrt(axis[0] * axis[0] + axis[1] * axis[1] + axis[2] * axis[2]);
            if (mag != 0)
            {
                axis[0] /= mag;
                axis[1] /= mag;
                axis[2] /= mag;
            }

            float radians = (float)(angle * MyPi / 180.0f);
            float sine = (float)Math.Sin(radians);
            float cosine = (float)Math.Cos(radians);
            float ab = axis[0] * axis[1] * (1 - cosine);
            float bc = axis[1] * axis[2] * (1 - cosine);
            float ca = axis[2] * axis[0] * (1 - cosine);
            float tx = axis[0] * axis[0];
            float ty = axis[1] * axis[1];
            float tz = axis[2] * axis[2];

            m[0] = tx + cosine * (1 - tx);
            m[1] = ab + axis[2] * sine;
            m[2] = ca - axis[1] * sine;
            m[3] = 0.0f;
            m[4] = ab - axis[2] * sine;
            m[5] = ty + cosine * (1 - ty);
            m[6] = bc + axis[0] * sine;
            m[7] = 0.0f;
            m[8] = ca + axis[1] * sine;
            m[9] = bc - axis[0] * sine;
            m[10] = tz + cosine * (1 - tz);
            m[11] = 0;
            m[12] = 0;
            m[13] = 0;
            m[14] = 0;
            m[15] = 1;
        }

        static void MakeTranslateMatrix(float x, float y, float z, float[] m)
        {
            m[0] = 1; m[1] = 0; m[2] = 0; m[3] = x;
            m[4] = 0; m[5] = 1; m[6] = 0; m[7] = y;
            m[8] = 0; m[9] = 0; m[10] = 1; m[11] = z;
            m[12] = 0; m[13] = 0; m[14] = 0; m[15] = 1;
        }

        /* Simple 4x4 matrix by 4x4 matrix multiply. */
        static void MultMatrix(float[] dst,
            float[] src1, float[] src2)
        {
            float[] tmp = new float[16];
            int i;

            for (i = 0; i < 4; i++)
            {
                int j;
                for (j = 0; j < 4; j++)
                {
                    tmp[i * 4 + j] = src1[i * 4 + 0] * src2[0 * 4 + j] +
                         src1[i * 4 + 1] * src2[1 * 4 + j] +
                         src1[i * 4 + 2] * src2[2 * 4 + j] +
                         src1[i * 4 + 3] * src2[3 * 4 + j];
                }
            }
            /* Copy result to dst (so dst can also be src1 or src2). */
            for (i = 0; i < 16; i++)
                dst[i] = tmp[i];
        }

        static void Reshape(int width, int height)
        {
            double aspectRatio = (float)width / height;
            const double FieldOfView = 40.0;

            /* Build projection matrix once. */
            BuildPerspectiveMatrix(FieldOfView, aspectRatio,
                       1.0, 20.0,  /* Znear and Zfar */
                       MyProjectionMatrix);
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}