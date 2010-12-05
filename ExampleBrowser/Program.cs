namespace ExampleBrowser
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        #region Methods

        #region Private Static Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExampleSelector());
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}