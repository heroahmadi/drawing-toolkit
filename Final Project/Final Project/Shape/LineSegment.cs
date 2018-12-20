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
    public class LineSegment : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public LineSegment() : base()
        {
            this.pen = new Pen(Color.Black);
        }

        public LineSegment(int initX, int initY) : this()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public LineSegment(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public LineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        private void DrawLogic(Color color)
        {
            pen.Color = color;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
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
            if (this.graphics != null)
            {
                this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void DrawPreview()
        {
            DrawLogic(Color.Black);
            if (this.graphics != null)
            {
                this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void DrawStatic()
        {
            DrawLogic(Color.Black);
            if (this.graphics != null)
            {
                this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
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

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }

        public override bool HitArea(int x, int y)
        {
            double m = GetSlope();
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * x + b;

            if (Math.Abs(y - y_point) < EPSILON)
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            this.Startpoint = new Point(this.Startpoint.X + x, this.Startpoint.Y + y);
            this.Endpoint = new Point(this.Endpoint.X + x, this.Endpoint.Y + y);
        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public override bool Add(DrawingObject obj)
        {
            return false;
        }

        public override bool Remove(DrawingObject obj)
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

        public override List<DrawingObject> GetDrawingObjects()
        {
            throw new NotImplementedException();
        }

    }
}
