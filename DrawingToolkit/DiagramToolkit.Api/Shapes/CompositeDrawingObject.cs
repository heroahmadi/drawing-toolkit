using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Api.Shapes
{
    class CompositeDrawingObject : DrawingObject
    {
        private List<DrawingObject> listDrawingObjects = new List<DrawingObject>();

        public override bool Add(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override bool Intersect(int xTest, int yTest)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override void RenderOnEditingView()
        {
            throw new NotImplementedException();
        }

        public override void RenderOnPreview()
        {
            throw new NotImplementedException();
        }

        public override void RenderOnStaticView()
        {
            throw new NotImplementedException();
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            throw new NotImplementedException();
        }
    }
}
