namespace ExampleBrowser.Examples.OpenTK
{
    using System;
    using System.Windows.Forms;

    using CgNet;

    using global::OpenTK;

    public abstract class Example : GameWindow, IExample
    {
        #region Constructors

        protected Example(string programName)
            : base(800, 600)
        {
            this.Title = programName;
        }

        #endregion Constructors

        #region Properties

        #region Protected Properties

        protected IntPtr CgContext
        {
            get;
            set;
        }

        #endregion Protected Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void Start()
        {
            Cg.SetErrorCallback(CheckForCgError);
            this.Run(30.0, 0.0);
        }

        #endregion Public Methods

        #region Protected Methods

        protected void CheckForCgError()
        {
            CgError error;
            string s = Cg.GetLastErrorString(out error);

            if (error != CgError.NoError)
            {
                MessageBox.Show(s);
                this.Close();

                var x = Cg.GetLastListing(this.CgContext);
            }
            //  printf("%s: %s: %s\n",
            //    myProgramName, situation, string);
            //  if (error == CG_COMPILER_ERROR) {
            //    printf("%s\n", cgGetLastListing(myCgContext));
            //  }
            //  exit(1);
            //}
        }

        #endregion Protected Methods

        #endregion Methods
    }
}