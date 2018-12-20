using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Final_Project.Shape
{
    public class UseCase : DrawingObject
    {

        public int cirX { get; set; }
        public int cirY { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }
        public string Value { get; set; }

        private Pen pen;
        private Brush brush;
        private Font font;
        private SizeF size;


        public UseCase()
        {
            this.Value = "Use Case";
            this.pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Black);
            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public UseCase(int initX, int initY) : this()
        {
            this.cirX = initX;
            this.cirY = initY;
        }

        public UseCase(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.cirWidth = initWidth;
            this.cirHeight = initHeight;
        }

        public override bool HitArea(int x, int y)
        {
            if ((x >= cirX && x <= cirX + cirWidth) && (y >= cirY && y <= cirY + cirHeight))
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            Point point = e.Location;
            cirX += x;
            cirY += y;
        }

        private void DrawLogic()
        {
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawEllipse(this.pen, cirX, cirY, cirWidth, cirHeight);
        }

        private void DrawText()
        {
            size = this.graphics.MeasureString(Value, font);
            float x = (cirWidth / 2) - (size.Width / 2) + this.cirX;
            float y = (cirHeight / 2) - (size.Height / 2) + this.cirY;
            PointF point = new PointF(x, y);
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.DrawString(Value, font, brush, point);
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

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            DrawLogic();
            DrawText();
        }

        public override Point GetCenterPoint()
        {
            //left
            Point point = new Point();
            point.X = cirX;
            point.Y = cirY + (cirHeight / 2);
            return point;
        }

        public override Point GetCenterPoint2()
        {
            //right
            Point point = new Point();
            point.X = cirX + cirWidth;
            point.Y = cirY + (cirHeight / 2);
            return point;
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
    }
}
