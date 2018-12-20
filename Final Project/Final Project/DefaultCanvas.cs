using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Project
{
    public class DefaultCanvas : Control, ICanvas
    {
        private ITool tool;
        private List<DrawingObject> drawingObjects;

        public DefaultCanvas()
        {
            this.drawingObjects = new List<DrawingObject>();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseMove += DefaultCanvas_MouseMove;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.KeyDown += DefaultCanvas_KeyDown;
            this.KeyUp += DefaultCanvas_KeyUp;
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject drawingObject in drawingObjects.Reverse<DrawingObject>())
            {
                drawingObject.graphics = e.Graphics;
                drawingObject.Draw();
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.tool != null)
            {
                this.tool.ToolMouseDown(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.tool != null)
            {
                this.tool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.tool != null)
            {
                this.tool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tool != null)
            {
                this.tool.ToolKeyDown(sender, e);
            }
        }

        private void DefaultCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.tool != null)
            {
                this.tool.ToolKeyUp(sender, e);
            }
        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(ITool tool)
        {
            this.tool = tool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
        }

        public void DeselectAll()
        {
            foreach (DrawingObject drawingObject in drawingObjects.Reverse<DrawingObject>())
            {
                drawingObject.Deselected();
            }
        }

        public DrawingObject GetObject(int x, int y)
        {
            foreach (DrawingObject drawingObject in drawingObjects.Reverse<DrawingObject>())
            {
                if (drawingObject.HitArea(x,y))
                {
                    return drawingObject;
                }
            }
            return null;
        }

        public DrawingObject SelectObject(int x, int y)
        {
            DrawingObject drawingObject = GetObject(x, y);
            if(drawingObject != null)
            {
                drawingObject.Selected();
            }
            return drawingObject;
        }

        public List<DrawingObject> GetAllObject()
        {
            return drawingObjects;
        }
    }
}
