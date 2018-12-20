using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Shape;

namespace Final_Project.Tool
{
    public class UseCaseTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private UseCase useCase;
        private string textValue;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas Canvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }

        }

        public UseCaseTool()
        {
            this.Name = "Use Case Tool";
            this.ToolTipText = "Use Case Tool";
            this.Image = IconSet.usecase;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.useCase = new UseCase(e.X, e.Y);
                DrawingObject drawingObject = canvas.GetObject(e.X, e.Y);

                if (drawingObject == null)
                {
                    canvas.AddDrawingObject(useCase);
                }
                else
                {
                    textValue = drawingObject.GetText();
                    using (TextForm textForm = new TextForm(textValue, drawingObject, canvas))
                    {
                        if (textForm.ShowDialog() == DialogResult.OK)
                        {
                            textForm.ShowDialog();
                        }
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.useCase.cirX;
                int height = e.Y - this.useCase.cirY;

                if (width > 0 && height > 0)
                {
                    this.useCase.cirWidth = width;
                    this.useCase.cirHeight = height;
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.useCase.Selected();
            }
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
