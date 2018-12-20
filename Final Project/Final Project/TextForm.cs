using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class TextForm : Form
    {
        private DrawingObject drawingObject;
        private ICanvas canvas;

        public TextForm(string input, DrawingObject drawingObject, ICanvas canvas)
        {
            InitializeComponent();
            this.textBox1.Text = input;
            this.drawingObject = drawingObject;
            this.canvas = canvas;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<DrawingObject> drawingObjects = canvas.GetAllObject();
            foreach(DrawingObject drawingObject in drawingObjects)
            {
                if (this.drawingObject == drawingObject)
                {
                    drawingObject.SetText(this.textBox1.Text);
                }
            }
            this.Close();
        }
    }
}
