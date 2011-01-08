namespace EffectViewer
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using CgNet;

    using CgOO;
    using CgOO.GL;

    class Analyzer
    {
        #region Fields

        private readonly Context context;
        private readonly TreeView treeView;

        #endregion Fields

        #region Constructors

        public Analyzer(TreeView treeView)
        {
            this.treeView = treeView;
            this.context = Context.Create();
            this.context.ParameterSettingMode = ParameterSettingMode.Deferred;
            this.context.RegisterStates();
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public void Analyse(string file)
        {
            if (File.Exists(file))
            {
                var effect = this.context.CreateEffectFromFile(file, null);
                if (effect == null)
                {
                    ErrorType error;
                    MessageBox.Show(Cg.GetLastErrorString(out error));
                    return;
                }

                // Techniques
                var techsNode = new TreeNode("Techniques");
                foreach (var technique in effect.Techniques)
                {
                    var techNode = new TreeNode(string.IsNullOrEmpty(technique.Name) ? techsNode.Nodes.Count.ToString() : technique.Name);

                    // Passes
                    var passesNode = new TreeNode("Passes");
                    foreach (var pass in technique.Passes)
                    {
                        var passNode = new TreeNode(string.IsNullOrEmpty(pass.Name) ? passesNode.Nodes.Count.ToString() : pass.Name);

                        // Programs
                        var programsNode = new TreeNode("Programs");
                        var vertexProgram = pass.GetProgram(Domain.VertexDomain);
                        if (vertexProgram != null)
                        {
                            programsNode.Nodes.Add(vertexProgram.GetProgramString(SourceType.ProgramEntry));
                        }
                        var fragmentProgram = pass.GetProgram(Domain.FragmentDomain);
                        if (fragmentProgram != null)
                        {
                            programsNode.Nodes.Add(fragmentProgram.GetProgramString(SourceType.ProgramEntry));
                        }
                        var geometryProgram = pass.GetProgram(Domain.GeometryDomain);
                        if (geometryProgram != null)
                        {
                            programsNode.Nodes.Add(geometryProgram.GetProgramString(SourceType.ProgramEntry));
                        }

                        if (programsNode.Nodes.Count > 0)
                        {
                            passNode.Nodes.Add(programsNode);
                        }

                        passesNode.Nodes.Add(passNode);
                    }

                    if (passesNode.Nodes.Count > 0)
                    {
                        techNode.Nodes.Add(passesNode);
                    }

                    techsNode.Nodes.Add(techNode);
                }

                this.treeView.Nodes.Add(techsNode);
            }
        }

        public void Destroy()
        {
            this.context.Dispose();
        }

        #endregion Public Methods

        #endregion Methods
    }
}