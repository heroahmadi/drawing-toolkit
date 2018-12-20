using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Final_Project.Shape
{
    public class Rectangle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Value { get; private set; }

        private Pen pen;
        public List<DrawingObject> listDrawingObjects;
        

        public Rectangle() : base()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            listDrawingObjects = new List<DrawingObject>();
        }

        public Rectangle(int initX, int initY) : this()
        {
            this.X = initX;
            this.Y = initY;
        }

        public Rectangle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.Width = initWidth;
            this.Height = initHeight;
        }

        private void DrawLogic(Color color)
        {
            this.pen.Color = color;
            this.pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawRectangle(this.pen, X, Y, Width, Height);

        }

        public override void DrawEdit()
        {
            DrawLogic(Color.Blue);
            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.graphics = this.graphics;
                obj.DrawEdit();
            }
        }

        public override void DrawPreview()
        {
            DrawLogic(Color.Black);
            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.graphics = this.graphics;
                obj.DrawPreview();
            }
        }

        public override void DrawStatic()
        {
            DrawLogic(Color.Black);
            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.graphics = this.graphics;
                obj.DrawStatic();
            }
        }

        public override Point GetCenterPoint()
        {
            Point point = new Point();
            //point.X = finishPoint.X;
            //point.Y = (startPoint.Y + finishPoint.Y) / 2;
            //return point;
            return point;
        }

        public override bool HitArea(int x, int y)
        {
            if ((x >= X && x <= X + this.Width) && (y >= Y && y <= Y + this.Height))
            {
                Debug.WriteLine("Object Rectangle is selected.");
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            this.X += x;
            this.Y += y;

            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.Move(x, y, e);
            }
        }

        public override string GetText()
        {
            return this.Value;
        }

        public override void SetText(string text)
        {
            this.Value = text;
        }

        public override bool Add(DrawingObject obj)
        {
            listDrawingObjects.Add(obj);
            return true;
        }

        public override bool Remove(DrawingObject obj)
        {
            listDrawingObjects.Remove(obj);
            return true;
        }

        public override Point GetCenterPoint2()
        {
            Point point = new Point();
            //point.X = startPoint.X;
            //point.Y = (startPoint.Y + finishPoint.Y) / 2;
            return point;
        }

        public override List<DrawingObject> GetDrawingObjects()
        {
            return this.listDrawingObjects;
        }
    }
}
