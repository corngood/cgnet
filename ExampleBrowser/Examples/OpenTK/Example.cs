namespace ExampleBrowser.Examples.OpenTK
{
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