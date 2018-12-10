using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class AddTextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Text text;
        private DrawingObject selectedObject;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
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

        public AddTextTool()
        {
            this.Name = "Add Text Tool";
            this.ToolTipText = "Add Text Tool";
            this.Image = IconSet.add_text_tool;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.selectedObject = canvas.GetObjectAt(e.X, e.Y);
                this.text = new Text(e.X, e.Y);
                text.Value = "Text";
                //canvas.AddDrawingObject(this.text);
                this.selectedObject.Add(this.text);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.text != null)
                {
                    int width = e.X - this.text.X;
                    int height = e.Y - this.text.Y;

                    if (width > 0 && height > 0)
                    {
                        //this.text.cirHeight = height;
                        //this.text.cirWidth = width;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.text != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    this.text.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.text);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
