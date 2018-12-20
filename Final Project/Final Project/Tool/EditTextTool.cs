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
                        canvas.DeselectAll();
                        canvas.SelectObject(e.X, e.Y);
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
                Char insertedKey = KeyToChar(e.KeyCode, e.Shift);
                Debug.WriteLine(e.KeyCode.ToString() + " pressed");
                this.selectedText.SetText(currentText + insertedKey);
            }
            canvas.Repaint();
        }

        public void ToolKeyPressDown(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public Char KeyToChar(Keys key, bool shift)
        {
            bool capslock = Control.IsKeyLocked(Keys.CapsLock);
            bool iscap = (capslock && !shift) || (!capslock && shift);
            switch (key)
            {
                case Keys.Enter: return '\n';
                case Keys.A: return (iscap ? 'A' : 'a');
                case Keys.B: return (iscap ? 'B' : 'b');
                case Keys.C: return (iscap ? 'C' : 'c');
                case Keys.D: return (iscap ? 'D' : 'd');
                case Keys.E: return (iscap ? 'E' : 'e');
                case Keys.F: return (iscap ? 'F' : 'f');
                case Keys.G: return (iscap ? 'G' : 'g');
                case Keys.H: return (iscap ? 'H' : 'h');
                case Keys.I: return (iscap ? 'I' : 'i');
                case Keys.J: return (iscap ? 'J' : 'j');
                case Keys.K: return (iscap ? 'K' : 'k');
                case Keys.L: return (iscap ? 'L' : 'l');
                case Keys.M: return (iscap ? 'M' : 'm');
                case Keys.N: return (iscap ? 'N' : 'n');
                case Keys.O: return (iscap ? 'O' : 'o');
                case Keys.P: return (iscap ? 'P' : 'p');
                case Keys.Q: return (iscap ? 'Q' : 'q');
                case Keys.R: return (iscap ? 'R' : 'r');
                case Keys.S: return (iscap ? 'S' : 's');
                case Keys.T: return (iscap ? 'T' : 't');
                case Keys.U: return (iscap ? 'U' : 'u');
                case Keys.V: return (iscap ? 'V' : 'v');
                case Keys.W: return (iscap ? 'W' : 'w');
                case Keys.X: return (iscap ? 'X' : 'x');
                case Keys.Y: return (iscap ? 'Y' : 'y');
                case Keys.Z: return (iscap ? 'Z' : 'z');
                case Keys.D0: return (shift ? ')' : '0');
                case Keys.D1: return (shift ? '!' : '1');
                case Keys.D2: return (shift ? '@' : '2');
                case Keys.D3: return (shift ? '#' : '3');
                case Keys.D4: return (shift ? '$' : '4');
                case Keys.D5: return (shift ? '%' : '5');
                case Keys.D6: return (shift ? '^' : '6');
                case Keys.D7: return (shift ? '&' : '7');
                case Keys.D8: return (shift ? '*' : '8');
                case Keys.D9: return (shift ? '(' : '9');
                case Keys.Add: return (shift ? '+' : '=');
                case Keys.OemMinus: return (shift ? '_' : '-');
                case Keys.OemQuestion: return (shift ? '?' : '/');
                case Keys.Oemcomma: return (shift ? '<' : ',');
                case Keys.OemPeriod: return (shift ? '>' : '.');
                case Keys.OemOpenBrackets: return (shift ? '{' : '[');
                case Keys.OemQuotes: return (shift ? '"' : '\'');
                case Keys.Oem1: return (shift ? ':' : ';');
                case Keys.Oem3: return (shift ? '~' : '`');
                case Keys.Oem5: return (shift ? '|' : '\\');
                case Keys.Oem6: return (shift ? '}' : ']');
                case Keys.Tab: return '\t';
                case Keys.Space: return '-';

                // Number Pad
                case Keys.NumPad0: return '0';
                case Keys.NumPad1: return '1';
                case Keys.NumPad2: return '2';
                case Keys.NumPad3: return '3';
                case Keys.NumPad4: return '4';
                case Keys.NumPad5: return '5';
                case Keys.NumPad6: return '6';
                case Keys.NumPad7: return '7';
                case Keys.NumPad8: return '8';
                case Keys.NumPad9: return '9';
                case Keys.Subtract: return '-';
                case Keys.Decimal: return '.';
                case Keys.Divide: return '/';
                case Keys.Multiply: return '*';

                default: return '\x00';
            }
        }
    }
}
