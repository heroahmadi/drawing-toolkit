using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project.Shape
{
    public class Circle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }
        public List<DrawingObject> listDrawingObjects = new List<DrawingObject>();
        public string Value { get; set; }

        private Pen pen;

        public Circle() : base()
        {
            this.pen = new Pen(Color.Black);
        }

        public Circle(int initX, int initY) : this()
        {
            this.X = initX;
            this.Y = initY;
        }

        public Circle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.cirWidth = initWidth;
            this.cirHeight = initHeight;
        }

        private void DrawLogic(Color color)
        {
            this.pen.Color = color;
            this.pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawEllipse(pen, X, Y, cirWidth, cirHeight);
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
            if ((x >= X && x <= X + cirWidth) && (y >= Y && y <= Y + cirHeight))
            {
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
