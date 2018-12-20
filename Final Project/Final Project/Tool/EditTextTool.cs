using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Shape;
using System.Drawing;
using System.Diagnostics;

namespace Final_Project.Tool
{
    public class EditTextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedText;
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

        public EditTextTool()
        {
            this.Name = "Edit Text Tool";
            this.ToolTipText = "Edit Text Tool";
            this.Image = IconSet.add_text_tool;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingObject selected_obj = canvas.GetObject(e.X, e.Y);
                foreach(DrawingObject obj in selected_obj.GetDrawingObjects())
                {
                    if (obj is Text)
                    {
                        Debug.WriteLine("text inside selected");
                        this.selectedText = obj;
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                return;
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            return;
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            String currentText = this.selectedText.GetText();
            if (e.KeyCode == Keys.Back)
            {
                Debug.WriteLine("Backspace pressed");
                this.selectedText.SetText(currentText.Remove(currentText.Length - 1));
            }
            else if (char.IsLetterOrDigit((char)e.KeyCode))
            {
                Char insertedKey;
                Debug.WriteLine(e.KeyCode.ToString() + " pressed");
                if (char.IsDigit((char)e.KeyCode))
                {
                     insertedKey = (char)(int)e.KeyCode;
                }
                else if (!Control.IsKeyLocked(Keys.CapsLock))
                {
                    insertedKey = e.KeyCode.ToString().ToLower()[0];
                }
                else
                {
                    insertedKey = e.KeyCode.ToString()[0];
                }
                this.selectedText.SetText(currentText + insertedKey);
            }
        }

        public void ToolKeyPressDown(object sender, KeyPressEventArgs e)
        {
            //String currentText = this.selectedText.GetText();
            //if(e.KeyChar == (char)Keys.Back)
            //{
            //    Debug.WriteLine("Backspace pressed");
            //    this.selectedText.SetText(currentText.Remove(currentText.Length - 1));
            //}
            //else
            //{
            //    String insertedString = e.KeyChar.ToString();
            //    if (!Control.IsKeyLocked(Keys.CapsLock))
            //    {
            //        insertedString = insertedString.ToLower();
            //    }
            //    Debug.WriteLine(insertedString + " pressed");
            //    this.selectedText.SetText(currentText + insertedString);
            //}
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
