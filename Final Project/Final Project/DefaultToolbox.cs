using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public class DefaultToolbox : ToolStrip, IToolbox
    {
        private ITool tool;

        public ITool ActiveTool
        {
            get
            {
                return this.tool;
            }
        }

        public event ToolSelectedEventHandler ToolSelected;

        public void AddTool(ITool tool)
        {
            if (tool is ToolStripButton)
            {
                ToolStripButton toolStripButton = (ToolStripButton)tool;
                if (toolStripButton.CheckOnClick)
                {
                    toolStripButton.CheckedChanged += toolStripButton_CheckedChanged;
                }
                this.Items.Add(toolStripButton);
            }
        }

        public void AddSeparator()
        {
            this.Items.Add(new ToolStripSeparator());
        }

        public void RemoveTool(ITool tool)
        {
            foreach (ToolStripItem toolStripItem in this.Items)
            {
                if (toolStripItem is ITool)
                {
                    if (toolStripItem.Equals(tool))
                    {
                        this.Items.Remove(toolStripItem);
                    }
                }
            }
        }

        private void toolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton toolStripButton = (ToolStripButton)sender;
                if (toolStripButton.Checked)
                {
                    if (toolStripButton is ITool)
                    {
                        this.tool = (ITool)toolStripButton;
                        if (ToolSelected != null)
                        {
                            ToolSelected(this.tool);
                        }
                        UncheckedInactiveTool();
                    }
                    else
                    {
                        throw new InvalidCastException("The tool is not an instance of ITool.");
                    }
                }
            }
        }

        private void UncheckedInactiveTool()
        {
            foreach (ToolStripItem item in this.Items)
            {
                if (item != this.tool)
                {
                    if(item is ToolStripButton)
                    {
                        ((ToolStripButton)item).Checked = false;
                    }
                }
            }
        }
    }
}
