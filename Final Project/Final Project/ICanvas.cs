using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public interface ICanvas
    {
        void SetActiveTool(ITool tool);
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);
        void Repaint();
        void DeselectAll();

        DrawingObject GetObject(int x, int y);
        DrawingObject SelectObject(int x, int y);

        List<DrawingObject> GetAllObject();
    }
}
