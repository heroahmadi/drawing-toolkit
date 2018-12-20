using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.State;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project.Tool
{
    public class SelectTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject drawingObject;
        Point point;
        private Boolean multiSelect = false;
        private List<DrawingObject> temp = new List<DrawingObject>();

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

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.select;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (drawingObject == null)
                {
                    canvas.DeselectAll();
                    temp.Clear();
                }
                else if (!multiSelect)
                {
                    drawingObject.ChangeState(StaticState.GetInstance());
                }
                drawingObject = canvas.SelectObject(e.X, e.Y);
                if (drawingObject != null)
                {
                    drawingObject.ChangeState(EditState.GetInstance());
                    if (multiSelect)
                    {
                        temp.Add(drawingObject);
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (drawingObject != null)
                {
                    int xMove = e.X - point.X;
                    int yMove = e.Y - point.Y;
                    point = e.Location;
                    drawingObject.Move(xMove, yMove, e);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                multiSelect = true;
            }
            else if (e.KeyCode == Keys.G)
            {
                if (temp.Count() > 1)
                {
                    DrawingGroup drawingGroup = new DrawingGroup();
                    foreach (DrawingObject drawingObject in temp)
                    {
                        drawingGroup.AddComposite(drawingObject);
                    }
                    drawingGroup.ChangeState(StaticState.GetInstance());
                    this.canvas.AddDrawingObject(drawingGroup);
                    temp.Clear();
                }
            }
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                multiSelect = false;
            }
        }
    }
}
