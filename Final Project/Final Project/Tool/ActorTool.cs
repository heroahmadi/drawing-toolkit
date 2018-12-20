using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Shape;
using System.Drawing;

namespace Final_Project.Tool
{
    public class ActorTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Actor actor;
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

        public ActorTool()
        {
            this.Name = "Actor Tool";
            this.ToolTipText = "Actor Tool";
            this.Image = IconSet.actor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actor = new Actor(new Point(e.X, e.Y));
                actor.finishPoint = new Point(e.X, e.Y);

                DrawingObject drawingObject = canvas.GetObject(e.X, e.Y);

                if (drawingObject == null)
                {
                    canvas.AddDrawingObject(actor);
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
                actor.finishPoint = new Point(e.X, e.Y);
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actor.finishPoint = new Point(e.X, e.Y);
                actor.Selected();
            }
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
