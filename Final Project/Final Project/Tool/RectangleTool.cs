using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Shape;
using System.Diagnostics;

namespace Final_Project.Tool
{
    public class RectangleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Rectangle rectangle;
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

        public RectangleTool()
        {
            this.Name = "Rectangle Tool";
            this.ToolTipText = "Rectangle Tool";
            this.Image = IconSet.actor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rectangle = new Rectangle(e.X, e.Y);
                DrawingObject drawingObject = canvas.GetObject(e.X, e.Y);

                if (drawingObject == null)
                {
                    canvas.AddDrawingObject(rectangle);
                }
                else
                {
                    textValue = drawingObject.GetText();
                    using (TextForm textForm = new TextForm(textValue, drawingObject, canvas))
                    {
                        if (textForm.ShowDialog() == DialogResult.OK)
                        {
                            textForm.ShowDialog();
                        }
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rectangle != null)
                {
                    int width = e.X - rectangle.X;
                    int height = e.Y - rectangle.Y;

                    if (width > 0 && height > 0)
                    {
                        rectangle.Height = height;
                        rectangle.Width = width;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.rectangle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    this.rectangle.Selected();
                }
                //else if (e.Button == MouseButtons.Right)
                //{
                //    canvas.RemoveDrawingObject(this.rectangle);
                //}
            }
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("oke");
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
