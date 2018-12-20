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
        private List<DrawingObject> listDrawingObjects;
        

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

        private void DrawLogic()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawRectangle(this.pen, X, Y, Width, Height);

        }

        //private void DrawText()
        //{
        //    size = this.graphics.MeasureString(Value, font);
        //    float x = (finishPoint.X + startPoint.X) / 2 - (size.Width / 2);
        //    float y = finishPoint.Y + 10;
        //    PointF point = new PointF(x, y);
        //    this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //    this.graphics.DrawString(Value, font, brush, point);
        //}

        public override void DrawEdit()
        {
            DrawLogic();
            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.graphics = this.graphics;
                obj.DrawEdit();
            }
        }

        public override void DrawPreview()
        {
            DrawLogic();
            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.graphics = this.graphics;
                obj.DrawPreview();
            }
        }

        public override void DrawStatic()
        {
            DrawLogic();
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

        public override bool Add(DrawingObject drawingObject)
        {
            return false;
        }

        public override bool Remove(DrawingObject drawingObject)
        {
            return false;
        }

        public override Point GetCenterPoint2()
        {
            Point point = new Point();
            //point.X = startPoint.X;
            //point.Y = (startPoint.Y + finishPoint.Y) / 2;
            return point;
        }
    }
}
