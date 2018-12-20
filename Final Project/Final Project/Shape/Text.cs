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
    public class Text : DrawingObject
    {
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;

        public Text() : base()
        {
            this.brush = new SolidBrush(Color.Black);

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public Text(int initX, int initY) : this()
        {
            this.X = initX;
            this.Y = initY;
        }

        private void DrawLogic()
        {
            this.graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = this.graphics.MeasureString(Value, font);
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
        }

        public override void DrawPreview()
        {
            DrawLogic();
        }

        public override void DrawStatic()
        {
            DrawLogic();
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
            if ((x >= X && x <= X + textSize.Width) && (y >= Y && y <= Y + textSize.Height))
            {
                Debug.WriteLine("Text selected");
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            this.X += x;
            this.Y += y;
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

        public override List<DrawingObject> GetDrawingObjects()
        {
            throw new NotImplementedException();
        }
    }
}
