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
    public class CircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle circle;
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

        public CircleTool()
        {
            this.Name = "Circle Tool";
            this.ToolTipText = "Circle Tool";
            this.Image = IconSet.circle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                circle = new Circle(e.X, e.Y);
                DrawingObject drawingObject = canvas.GetObject(e.X, e.Y);

                if (drawingObject == null)
                {
                    canvas.AddDrawingObject(circle);
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
                if (circle != null)
                {
                    int width = e.X - circle.X;
                    int height = e.Y - circle.Y;

                    if (width > 0 && height > 0)
                    {
                        circle.cirHeight = height;
                        circle.cirWidth = width;
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
                    this.circle.Selected();
                }
                //else if (e.Button == MouseButtons.Right)
                //{
                //    canvas.RemoveDrawingObject(this.circle);
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
