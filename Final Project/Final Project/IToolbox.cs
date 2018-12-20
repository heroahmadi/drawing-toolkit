using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public delegate void ToolSelectedEventHandler(ITool tool);

    public interface IToolbox
    {
        event ToolSelectedEventHandler ToolSelected;
        void AddTool (ITool tool);
        void AddSeparator();
        void RemoveTool (ITool tool);
        ITool ActiveTool { get; }
    }
}
