namespace ExampleBrowser.Examples.CgNet.SlimDX.Basic
{
    using System;
    using System.Windows.Forms;

    using global::CgNet;
    using global::CgNet.CgNet.D3D9;

    using global::Examples.Helper;

    using global::SlimDX;
    using global::SlimDX.Direct3D9;
    using global::SlimDX.Windows;

    [Example(NodePath = "CgNet/SlimDX/Basic/02 Vertex And Fragment Program")]
    public class VertexFragmentProgram : Example
    {
        #region Fields

        private readonly StarList[] myStarList = {
                                                     /*                star    outer   inner  */
                                                     /*  x       y     Points  radius  radius */
                                                     /* =====   =====  ======  ======  ====== */
                                                     new StarList(-0.1f, 0, 5, 0.5f, 0.2f),
                                                     new StarList(-0.84f, 0.1f, 5, 0.3f, 0.12f),
                                                     new StarList(0.92f, -0.5f, 5, 0.25f, 0.11f),
                                                     new StarList(0.3f, 0.97f, 5, 0.3f, 0.1f),
                                                     new StarList(0.94f, 0.3f, 5, 0.5f, 0.2f),
                                                     new StarList(-0.97f, -0.8f, 5, 0.6f, 0.2f)
                                                 };

        private Device device;
        private IntPtr myCgContext;
        private ProfileType myCgVertexProfile, myCgFragmentProfile;
        private IntPtr myCgVertexProgram, myCgFragmentProgram;

        private const string MyVertexProgramFileName = "Data/C2E1v_green.cg";

        private const string MyVertexProgramName = "C2E1v_green";

        private const string MyFragmentProgramFileName = "Data/C2E2f_passthru.cg";

        private const string MyFragmentProgramName = "C2E2f_passthru";

        private const int MyStarCount = 6;
        private VertexBuffer vertexBuffer;

        #endregion Fields

        #region Methods

        #region Public Methods

        public override void Start()
        {
            base.Start();
            var form = new RenderForm("02_vertex_and_fragment_program");
            this.device = new Device(new Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters
                                                                                                                                {
                                                                                                                                    BackBufferWidth = form.ClientSize.Width,
                                                                                                                                    BackBufferHeight = form.ClientSize.Height
                                                                                                                                });
            int vertexCount = 0;

            for (int i = 0; i < MyStarCount; i++)
            {
                vertexCount += myStarList[i].Points * 2 + 2;
            }

            vertexBuffer = new VertexBuffer(device, vertexCount * 12, Usage.WriteOnly, VertexFormat.Position, Pool.Default);

            Vector3[] starVertices = new Vector3[vertexCount];
            var dataStream = vertexBuffer.Lock(0, 0, LockFlags.Discard);
            for (int i = 0, n = 0; i < myStarList.Length; i++)
            {
                double piOverStarPoints = 3.14159 / myStarList[i].Points;
                float x = myStarList[i].X,
                      y = myStarList[i].Y,
                      outerRadius = myStarList[i].OuterRadius,
                      r = myStarList[i].InnerRadius;
                double angle = 0.0;

                /* Center of star */
                starVertices[n++] = new Vector3(x, y, 0);
                /* Emit exterior vertices for star's points. */
                for (int j = 0; j < myStarList[i].Points; j++)
                {
                    starVertices[n++] = new Vector3(x + outerRadius * (float)Math.Cos(angle), y + outerRadius * (float)Math.Sin(angle), 0);
                    angle -= piOverStarPoints;
                    starVertices[n++] = new Vector3(x + r * (float)Math.Cos(angle), y + r * (float)Math.Sin(angle), 0);
                    angle -= piOverStarPoints;
                }
                /* End by repeating first exterior vertex of star. */
                angle = 0;
                starVertices[n++] = new Vector3(x + outerRadius * (float)Math.Cos(angle), y + outerRadius * (float)Math.Sin(angle), 0);
            }
            dataStream.WriteRange(starVertices);
            dataStream.Position = 0;
            vertexBuffer.Unlock();

            myCgContext = Cg.CreateContext();
            Cg.SetParameterSettingMode(myCgContext, ParameterSettingMode.Deferred);
            this.CreateCgPrograms();

            form.Show();
            while (form.Visible)
            {
                device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, new Color4(0.1f, 0.3f, 0.6f), 1.0f, 0);
                device.BeginScene();

                CgD3D9.BindProgram(myCgVertexProgram);
                CgD3D9.BindProgram(myCgFragmentProgram);
                /* Render the triangle. */
                device.SetStreamSource(0, vertexBuffer, 0, 12);
                device.VertexFormat = VertexFormat.Position;
                for (int i = 0; i < MyStarCount; i++)
                {
                    device.DrawPrimitives(PrimitiveType.TriangleFan, i * 12, 10);
                }
                device.EndScene();
                device.Present();
                Application.DoEvents();
            }

            Cg.DestroyProgram(this.myCgFragmentProgram);
            Cg.DestroyProgram(this.myCgVertexProgram);
            Cg.DestroyContext(this.myCgContext);
            foreach (var item in ObjectTable.Objects)
            {
                item.Dispose();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateCgPrograms()
        {
            CgD3D9.SetDevice(this.device);
            /* Determine the best profile once a device to be set. */
            myCgVertexProfile = CgD3D9.GetLatestVertexProfile();

            string[] profileOpts = CgD3D9.GetOptimalOptions(myCgVertexProfile);

            myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    myCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyVertexProgramFileName, /* Name of file containing program */
                    myCgVertexProfile, /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName, /* Entry function name */
                    profileOpts); /* Pass optimal compiler options */

            myCgFragmentProfile = CgD3D9.GetLatestPixelProfile();
            profileOpts = CgD3D9.GetOptimalOptions(myCgFragmentProfile);
            myCgFragmentProgram =
                Cg.CreateProgramFromFile(
                    myCgContext,
                    ProgramType.Source,
                    MyFragmentProgramFileName,
                    myCgFragmentProfile,
                    MyFragmentProgramName,
                    profileOpts);

            CgD3D9.LoadProgram(myCgVertexProgram, false, 0);
            CgD3D9.LoadProgram(myCgFragmentProgram, false, 0);
        }

        #endregion Private Methods

        #endregion Methods

        #region Nested Types

        private struct StarList
        {
            #region Fields

            public readonly float OuterRadius;
            public readonly float InnerRadius;
            public readonly int Points;
            public readonly float X;
            public readonly float Y;

            #endregion Fields

            #region Constructors

            public StarList(float x, float y, int points, float or, float ir)
            {
                this.X = x;
                this.Y = y;
                this.Points = points;
                this.OuterRadius = or;
                this.InnerRadius = ir;
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}