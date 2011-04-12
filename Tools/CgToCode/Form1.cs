namespace CgToCode
{
    using System;
    using System.Windows.Forms;

    using CgNet;

    public partial class Form1 : Form
    {
        #region Fields

        private Converter converter = new Converter();

        #endregion Fields

        #region Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.CurrentDirectory;
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = ofd.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.converter.Convert(this.textBox1.Text, this.textBox2.Text, ProfileType.Arbvp1, "Test", "TestNamespace", Environment.CurrentDirectory);
        }

        #endregion Private Methods

        #endregion Methods
    }
}