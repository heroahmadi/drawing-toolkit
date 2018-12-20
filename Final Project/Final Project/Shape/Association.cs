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
    class Association : DrawingObject, IObserver
    {
        private const double EPSILON = 3.0;
        public Point startPoint;
        public Point finishPoint;
        private Pen pen;

        public DrawingObject objectSource;
        public DrawingObject objectDestination;

        public Association(DrawingObject objectSource, DrawingObject objectDestination)
        {
            this.pen = new Pen(Color.Black);
            this.objectSource = objectSource;
            this.objectDestination = objectDestination;
            Update();
        }

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            
        }

        public override void DrawStatic()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
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
