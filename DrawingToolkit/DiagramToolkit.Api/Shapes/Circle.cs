using DiagramToolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Circle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }
        private List<DrawingObject> listDrawingObjects = new List<DrawingObject>();

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

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + cirWidth) && (yTest >= Y && yTest <= Y + cirHeight))
            {
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawEllipse(pen, X, Y, cirWidth, cirHeight);

            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnEditingView();
            }
        }
        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawEllipse(pen, X, Y, cirWidth, cirHeight);

            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnEditingView();
            }
        }
        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            GetGraphics().DrawEllipse(pen, X, Y, cirWidth, cirHeight);

            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnPreview();
            }
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;

            foreach (DrawingObject obj in listDrawingObjects)
            {
                obj.Translate(x, y, xAmount, yAmount);
            }
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
    }
}
