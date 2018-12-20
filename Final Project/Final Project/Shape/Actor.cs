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
    public class Actor : DrawingObject
    {
        private const double EPSILON = 3.0;
        private Pen pen;
        public Point startPoint { get; set; }
        public Point finishPoint { get; set; }
        public string Value { get; set; }

        private Brush brush;
        private Font font;
        private SizeF size;

        public Actor()
        {
            this.Value = "Actor";
            this.pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Black);
            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public Actor(Point initX) : this()
        {
            this.startPoint = initX;
        }

        public Actor(Point initX, Point initY) : this(initX)
        {
            this.finishPoint = initY;
        }

        private void DrawLogic()
        {
            Point joint = new Point((finishPoint.X + startPoint.X) / 2, (int)(startPoint.Y + (finishPoint.Y - startPoint.Y) * 0.7));
            Point joint2 = new Point((finishPoint.X + startPoint.X) / 2, (int)(startPoint.Y + (finishPoint.Y - startPoint.Y) * 0.3));

            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawEllipse(pen, startPoint.X + (finishPoint.X - startPoint.X) / 4 , startPoint.Y, (finishPoint.X - startPoint.X) / 2, (int)((finishPoint.Y - startPoint.Y) * 0.25));
            this.graphics.DrawLine(pen, joint, this.finishPoint);
            this.graphics.DrawLine(pen, new Point(startPoint.X, finishPoint.Y), joint);
            this.graphics.DrawLine(pen, new Point((finishPoint.X + startPoint.X) / 2, (int)(startPoint.Y + (finishPoint.Y - startPoint.Y) * 0.25)), joint);
            this.graphics.DrawLine(pen, joint2, new Point(finishPoint.X, (int)(startPoint.Y + (finishPoint.Y - startPoint.Y) * 0.6)));
            this.graphics.DrawLine(pen, new Point(startPoint.X, (int)(startPoint.Y + (finishPoint.Y - startPoint.Y) * 0.6)), joint2);
            
        }

        private void DrawText()
        {
            size = this.graphics.MeasureString(Value, font);
            float x = (finishPoint.X + startPoint.X) / 2 - (size.Width / 2);
            float y = finishPoint.Y + 10;
            PointF point = new PointF(x, y);
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawString(Value, font, brush, point);
        }

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            DrawLogic();
            DrawText();
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            DrawLogic();
            DrawText();
        }

        public override void DrawStatic()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            DrawLogic();
            DrawText();
        }

        public override Point GetCenterPoint()
        {
            Point point = new Point();
            point.X = finishPoint.X;
            point.Y = (startPoint.Y + finishPoint.Y) / 2;
            return point;
        }

        public override bool HitArea(int x, int y)
        {
            if ((x >= startPoint.X && x <= finishPoint.X) && (y >= startPoint.Y && y <= finishPoint.Y))
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
            point.X = startPoint.X;
            point.Y = (startPoint.Y + finishPoint.Y) / 2;
            return point;
        }
    }
}
