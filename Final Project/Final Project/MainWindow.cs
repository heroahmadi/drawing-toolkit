using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Tool;

namespace Final_Project
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;

        public MainWindow()
        {
            InitializeComponent();

            #region Canvas
            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);
            #endregion

            #region Toolbox
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);
            #endregion

            #region Tool
            this.toolbox.AddTool(new SelectTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new ActorTool());
            this.toolbox.AddTool(new UseCaseTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new AssociationTool());
            this.toolbox.AddTool(new ConnectorTool());
            this.toolbox.AddTool(new ConnectorDotDotTool());
            this.toolbox.AddTool(new GeneralizationTool());
            this.toolbox.AddTool(new IncludeTool());
            this.toolbox.AddTool(new ExtendTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;
            #endregion
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.Canvas = this.canvas;
            }
        }
    }
}
