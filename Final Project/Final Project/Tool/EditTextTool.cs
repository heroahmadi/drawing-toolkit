using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Shape;
using System.Drawing;
using System.Diagnostics;

namespace Final_Project.Tool
{
    public class EditTextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedText;
        private string textValue;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas Canvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public EditTextTool()
        {
            this.Name = "Edit Text Tool";
            this.ToolTipText = "Edit Text Tool";
            this.Image = IconSet.add_text_tool;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingObject selected_obj = canvas.GetObject(e.X, e.Y);
                foreach(DrawingObject obj in selected_obj.GetDrawingObjects())
                {
                    if (obj is Text)
                    {
                        Debug.WriteLine("text inside selected");
                        this.selectedText = obj;
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                return;
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            return;
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            String currentText = this.selectedText.GetText();
            this.selectedText.SetText(currentText + e.KeyCode.ToString());
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
