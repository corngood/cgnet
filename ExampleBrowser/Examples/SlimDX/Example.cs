namespace ExampleBrowser.Examples.SlimDX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using global::CgNet;

    public abstract class Example : IExample
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }

        public virtual void Start()
        {
            Cg.ErrorCallback = this.CheckForCgError;
        }

        #endregion Public Methods

        #region Protected Methods

        protected void CheckForCgError()
        {
            ErrorType error;
            string s = Cg.GetLastErrorString(out error);
        
            if (error != ErrorType.NoError)
            {
                MessageBox.Show(s);
            }
            //  printf("%s: %s: %s\n",
            //    myProgramName, situation, string);
            //  if (error == CG_COMPILER_ERROR) {
            //    printf("%s\n", cgGetLastListing(CgContext));
            //  }
            //  exit(1);
            //}
        }

        #endregion Protected Methods

        #endregion Methods
    }
}