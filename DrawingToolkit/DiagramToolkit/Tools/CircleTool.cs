using DrawingToolkit.Shapes;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class CircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle circle;

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

        public CircleTool()
        {
            this.Name = "Curcke Tool";
            this.ToolTipText = "Circle Tool";
            this.Image = IconSet.circle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.circle = new Circle(e.X, e.Y);
                canvas.AddDrawingObject(this.circle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.circle != null)
                {
                    int width = e.X - this.circle.X;
                    int height = e.Y - this.circle.Y;

                    if(width > 0 && height > 0)
                    {
                        this.circle.cirHeight = height;
                        this.circle.cirWidth = width;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.circle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    this.circle.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.circle);
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
