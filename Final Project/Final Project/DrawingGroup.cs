using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Project
{
    public class DrawingGroup : DrawingObject
    {
        private List<DrawingObject> drawingGroups = new List<DrawingObject>();

        public void AddComposite(DrawingObject drawingObject)
        {
            this.drawingGroups.Add(drawingObject);
        }

        public void RemoveComposite(DrawingObject drawingObject)
        {
            this.drawingGroups.Remove(drawingObject);
        }

        public override void ChangeState(DrawingState state)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.ChangeState(state);
            }
            this.state = state;
        }

        public override void DrawEdit()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.DrawEdit();
            }
        }

        public override void DrawStatic()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.DrawStatic();
            }
        }

        public override void DrawPreview()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.DrawPreview();
            }
        }

        public override bool HitArea(int x, int y)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                if (drawingObject.HitArea(x, y))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Move(x, y, e);
            }
        }

        public override void Selected()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Selected();
            }
        }

        public override void Deselected()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Deselected();
            }
        }

        public override void Draw()
        {

        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public override bool Add(DrawingObject drawingObject)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject drawingObject)
        {
            throw new NotImplementedException();
        }

        public override Point GetCenterPoint2()
        {
            throw new NotImplementedException();
        }
    }
}
