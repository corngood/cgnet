namespace EffectViewer
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        #region Fields

        private readonly Analyzer analyzer;

        #endregion Fields

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            this.analyzer = new Analyzer(this.treeView1);
        }

        #endregion Constructors

        #region Methods

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
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
            this.analyzer.Analyse(this.textBox1.Text);
        }

        #endregion Private Methods

        #endregion Methods
    }
}