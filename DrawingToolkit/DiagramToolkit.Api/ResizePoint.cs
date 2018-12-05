using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public class ResizePoint
    {
        private int x_pos;
        private int y_pos;
        private Graphics graphics;

        public ResizePoint(int x, int y)
        {
            this.x_pos = x;
            this.y_pos = y;
        }

        public void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void Draw()
        {
            SolidBrush blueBrush = new SolidBrush(Color.Gray);
            this.graphics.FillRectangle(blueBrush, this.x_pos, this.y_pos, 5, 5);
        }

        //public void Draw()
        //{
        //    Graphics graphics;
        //    graphics = this.CreateGraphics();
        //    SolidBrush blueBrush = new SolidBrush(Color.Blue);
        //    graphics.FillRectangle();
        //}
    }
}
