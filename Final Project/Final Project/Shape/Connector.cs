using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Final_Project.Shape
{
    class Connector : DrawingObject, IObserver
    {
        private const double EPSILON = 3.0;
        public Point startPoint;
        public Point finishPoint;
        private Pen pen;

        public DrawingObject objectSource;
        public DrawingObject objectDestination;

        public Connector(DrawingObject objectSource, DrawingObject objectDestination)
        {
            this.pen = new Pen(Color.Black);
            this.objectSource = objectSource;
            this.objectDestination = objectDestination;
            Update();
        }

        public void arrow()
        {
            PointF point = this.finishPoint;

            double length = Math.Sqrt(Math.Pow(Math.Abs(startPoint.X - finishPoint.X), 2) + Math.Pow(Math.Abs(startPoint.Y - finishPoint.Y), 2));

            double angle = Math.Atan2(Math.Abs(startPoint.Y - finishPoint.Y), Math.Abs(startPoint.X - finishPoint.X));

            double pointX, pointY;
            if(startPoint.X > finishPoint.X)
            {
                pointX = startPoint.X - (Math.Cos(angle) * (length - (3 * 5)));
            }
            else
            {
                pointX = Math.Cos(angle) * (length - (3 * 5)) + startPoint.X;
            }
            if(startPoint.Y > finishPoint.Y)
            {
                pointY = startPoint.Y - (Math.Sin(angle) * (length - (3 * 5)));
            }
            else
            {
                pointY = (Math.Sin(angle) * (length - (3 * 5))) + startPoint.Y;
            }

            double angleA = Math.Atan2((3 * 5), (length - (3 * 5)));
            double angleB = Math.PI * (90 - (angle * (180 / Math.PI)) - (angleA * (180 / Math.PI))) / 180;

            double length2 = (3 * 5) / Math.Sin(angleA);

            if (startPoint.X > finishPoint.X)
            {
                pointX = startPoint.X - (Math.Sin(angleB) * length2);
            }
            else
            {
                pointX = (Math.Sin(angleB) * length2) + startPoint.X;
            }

            if (startPoint.Y > finishPoint.Y)
            {
                pointY = startPoint.Y - (Math.Cos(angleB) * length2);
            }
            else
            {
                pointY = (Math.Cos(angleB) * length2) + startPoint.Y;
            }

            PointF pointLeft = new PointF((float)pointX, (float)pointY);

            angleB = angle - angleA;

            if (startPoint.X > finishPoint.X)
            {
                pointX = startPoint.X - (Math.Cos(angleB) * length2);
            }
            else
            {
                pointX = (Math.Cos(angleB) * length2) + startPoint.X;
            }

            if (startPoint.Y > finishPoint.Y)
            {
                pointY = startPoint.Y - (Math.Sin(angleB) * length2);
            }
            else
            {
                pointY = (Math.Sin(angleB) * length2) + startPoint.Y;
            }

            PointF pointRight = new PointF((float)pointX, (float)pointY);

            PointF[] arrowPoints = new PointF[3];
            arrowPoints[0] = point;
            arrowPoints[1] = pointLeft;
            arrowPoints[2] = pointRight;

            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            this.graphics.DrawLine(pen, pointLeft, point);
            this.graphics.DrawLine(pen, pointRight, point);

        }

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            arrow();
        }

        public override void DrawStatic()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            arrow();
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            arrow();
        }

        public override bool HitArea(int x, int y)
        {
            double a = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - a * finishPoint.X;
            double c = a * x + b;

            if (Math.Abs(y - c) < EPSILON)
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            Point point = e.Location;
            this.startPoint = new Point(this.startPoint.X + x, this.startPoint.Y + y);
            this.finishPoint = new Point(this.finishPoint.X + x, this.finishPoint.Y + y);
        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            if (this.startPoint.X < this.finishPoint.X)
            {
                this.startPoint = objectSource.GetCenterPoint();
                this.finishPoint = objectDestination.GetCenterPoint();
            }
            else
            {
                this.startPoint = objectSource.GetCenterPoint2();
                this.finishPoint = objectDestination.GetCenterPoint2();
            }

        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public override bool Add(DrawingObject drawingObject)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject drawingObject)
        {
            throw new NotImplementedException();
        }

        public override Point GetCenterPoint2()
        {
            throw new NotImplementedException();
        }
    }
}
