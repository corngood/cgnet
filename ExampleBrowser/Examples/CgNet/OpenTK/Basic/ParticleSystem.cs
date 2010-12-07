namespace ExampleBrowser.Examples.CgNet.OpenTK.Basic
{
    using System;

    using global::CgNet;
    using global::CgNet.GL;

    using ExampleBrowser.Examples.CgNet.OpenTK;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics;
    using global::OpenTK.Input;

    using BeginMode = global::OpenTK.Graphics.OpenGL.BeginMode;
    using BlendingFactorDest = global::OpenTK.Graphics.OpenGL.BlendingFactorDest;
    using BlendingFactorSrc = global::OpenTK.Graphics.OpenGL.BlendingFactorSrc;
    using ClearBufferMask = global::OpenTK.Graphics.OpenGL.ClearBufferMask;
    using EnableCap = global::OpenTK.Graphics.OpenGL.EnableCap;
    using GL = global::OpenTK.Graphics.OpenGL.GL;
    using MatrixMode = global::OpenTK.Graphics.OpenGL.MatrixMode;
    using TextureUnit = global::OpenTK.Graphics.OpenGL.TextureUnit;

    [Example(NodePath = "CgNet/OpenTK/Basic/15 Particle System")]
    public class ParticleSystem : Example
    {
        #region Fields

        private const string MyFragmentProgramFileName = "Data/C6E2v_particle.cg";
        private const string MyFragmentProgramName = "texcoord2color";
        private const string MyVertexProgramFileName = "Data/C6E2v_particle.cg";
        private const string MyVertexProgramName = "C6E2v_particle";

        private readonly Particle[] myParticleSystem = new Particle[800];

        private static bool useComputedPointSize;

        private IntPtr myCgVertexParamGlobalTime, myCgVertexParamAcceleration, myCgVertexParamModelViewProj;
        private ProfileType myCgVertexProfile, myCgFragmentProfile;
        private IntPtr myCgVertexProgram, myCgFragmentProgram;
        private float myGlobalTime;
        private int myPass;

        #endregion Fields

        #region Constructors

        public ParticleSystem()
            : base("15_particle_system")
        {
        }

        #endregion Constructors

        #region Methods

        #region Protected Methods

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            switch (e.KeyChar)
            {
                case 'p':
                    useComputedPointSize = !useComputedPointSize;
                    if (useComputedPointSize)
                    {
                        GL.Enable(EnableCap.VertexProgramPointSize);
                    }
                    else
                    {
                        GL.Disable(EnableCap.VertexProgramPointSize);
                    }
                    break;

                case 'r':
                    this.ResetParticles();
                    break;
            }
        }

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            this.ResetParticles();

            GL.ClearColor(0.2f, 0.6f, 1.0f, 1); /* Blue background */
            GL.PointSize(6.0f);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture1D);
            this.MyCgContext = Cg.CreateContext();
            CgGL.SetDebugMode(false);

            myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(myCgVertexProfile);

            myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyVertexProgramFileName, /* Name of file containing program */
                    myCgVertexProfile, /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */

            CgGL.LoadProgram(myCgVertexProgram);

            this.myCgVertexParamGlobalTime =
                Cg.GetNamedParameter(myCgVertexProgram, "globalTime");

            this.myCgVertexParamAcceleration =
                Cg.GetNamedParameter(myCgVertexProgram, "acceleration");

            this.myCgVertexParamModelViewProj =
                Cg.GetNamedParameter(myCgVertexProgram, "modelViewProj");

            myCgFragmentProfile = CgGL.GetLatestProfile(ProfileClass.Fragment);
            CgGL.SetOptimalOptions(myCgFragmentProfile);

            myCgFragmentProgram =
                Cg.CreateProgramFromFile(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyFragmentProgramFileName, /* Name of file containing program */
                    myCgFragmentProfile, /* Profile: OpenGL ARB vertex program */
                    MyFragmentProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            CgGL.LoadProgram(myCgFragmentProgram);
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            const float Acceleration = -9.8f;
            float viewAngle = myGlobalTime * 2.8f;
            int i;

            GL.LoadIdentity();
            Glu.LookAt((float)Math.Cos(viewAngle), 0.3f, (float)Math.Sin(viewAngle),
                       0, 0, 0, 0, 1, 0);
            /* Set uniforms before glGLProgram bind. */
            Cg.SetParameter(this.myCgVertexParamGlobalTime, myGlobalTime);
            Cg.SetParameter(this.myCgVertexParamAcceleration, 0, Acceleration, 0, 0);
            CgGL.SetStateMatrixParameter(this.myCgVertexParamModelViewProj,
                                         MatrixType.ModelviewProjectionMatrix,
                                         MatrixTransform.MatrixIdentity);

            CgGL.BindProgram(myCgVertexProgram);

            CgGL.EnableProfile(myCgVertexProfile);

            CgGL.BindProgram(myCgFragmentProgram);

            CgGL.EnableProfile(myCgFragmentProfile);

            /* Render live particles. */
            GL.Begin(BeginMode.Points);
            for (i = 0; i < 800; i++)
            {
                if (myParticleSystem[i].Alive)
                {
                    /* initial velocity */
                    GL.TexCoord3(myParticleSystem[i].VInitial);
                    /* initial time */
                    GL.MultiTexCoord1(TextureUnit.Texture1, myParticleSystem[i].Initial);
                    /* initial position */
                    GL.Vertex3(myParticleSystem[i].PInitial);
                }
            }
            GL.End();

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
            GL.Viewport(0, 0, this.Width, this.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            Cg.DestroyProgram(this.myCgVertexProgram);
            Cg.DestroyProgram(myCgFragmentProgram);
            Cg.DestroyContext(this.MyCgContext);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            myGlobalTime += .01f;
            this.AdvanceParticles();

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void AdvanceParticles()
        {
            Random r = new Random();
            float deathTime = myGlobalTime - 1.0f;
            int i;

            myPass++;
            for (i = 0; i < 800; i++)
            {
                /* Birth new particles. */
                if (!myParticleSystem[i].Alive &&
                    (myParticleSystem[i].Initial <= myGlobalTime))
                {
                    myParticleSystem[i].VInitial = new float[3];
                    myParticleSystem[i].VInitial[0] = (float)(r.NextDouble() * 2 - 1);
                    myParticleSystem[i].VInitial[1] = (float)(r.NextDouble() * 6);
                    myParticleSystem[i].VInitial[2] = (float)(r.NextDouble() - 0.5);
                    myParticleSystem[i].Initial = myGlobalTime;
                    myParticleSystem[i].Alive = true;
                }

                /* Kill old particles.  A particle expires in this system when it
                   is 20 passes old. */
                if (myParticleSystem[i].Alive
                    && (myParticleSystem[i].Initial <= deathTime))
                {
                    myParticleSystem[i].Alive = false;
                    myParticleSystem[i].Initial = myGlobalTime + .01f; /* Rebirth next pass */
                }
            }
        }

        private void ResetParticles()
        {
            int i;

            myGlobalTime = 0.0f;
            myPass = 0;
            Random r = new Random();
            /* Particles will start at random times to gradually get things rolling. */
            for (i = 0; i < 800; i++)
            {
                const float Radius = 0.25f;
                const float InitialElevation = -0.5f;
                myParticleSystem[i].PInitial = new float[3];
                myParticleSystem[i].PInitial[0] = Radius * (float)Math.Cos(i * 0.5f);
                myParticleSystem[i].PInitial[1] = InitialElevation;
                myParticleSystem[i].PInitial[2] = Radius * (float)Math.Sin(i * 0.5f);
                myParticleSystem[i].Alive = false;
                myParticleSystem[i].Initial = (float)(r.NextDouble() * 10);
            }
        }

        #endregion Private Methods

        #endregion Methods

        #region Nested Types

        private struct Particle
        {
            #region Fields

            public bool Alive;
            public float Initial;
            public float[] PInitial;
            public float[] VInitial;

            #endregion Fields
        }

        #endregion Nested Types
    }
}