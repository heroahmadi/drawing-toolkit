using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public interface ITool
    {
        String Name { get; set; }
        Cursor Cursor { get; }
        ICanvas Canvas { get; set; }

        void ToolMouseDown(object sender, MouseEventArgs e);
        void ToolMouseMove(object sender, MouseEventArgs e);
        void ToolMouseUp(object sender, MouseEventArgs e);
        void ToolKeyDown(object sender, KeyEventArgs e);
        void ToolKeyUp(object sender, KeyEventArgs e);
    }
}
