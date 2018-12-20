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
    public class AddTextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Text text;
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
                DrawingObject drawingObject = canvas.GetObject(e.X, e.Y);
                this.text = new Text(e.X, e.Y);
                text.Value = "Text";
                drawingObject.Add(this.text);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (text != null)
                {
                    int width = e.X - text.X;
                    int height = e.Y - text.Y;

                    if (width > 0 && height > 0)
                    {
                        //text. = height;
                        //text.cirWidth = width;
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
                    this.text.Selected();
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

        public void ToolKeyPressDown(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("oke");
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
