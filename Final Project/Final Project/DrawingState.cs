using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public abstract class DrawingState
    {
        private DrawingState state;
        public abstract void Draw(DrawingObject drawingObject);

        public virtual void Selected(DrawingObject drawingObject)
        {

        }

        public virtual void Deselected(DrawingObject drawingObject)
        {

        }

        public DrawingState drawingState
        {
            get
            {
                return this.state;
            }
        }

    }
}
