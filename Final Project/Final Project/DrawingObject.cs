using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.State;

namespace Final_Project
{
    public abstract class DrawingObject : IObservable
    {

        List<IObserver> observers = new List<IObserver>();

        public Guid guid { get; set; }
        public Graphics graphics { get; set; }
        public abstract bool HitArea(int x, int y);
        public abstract void Move(int x, int y, MouseEventArgs e);
        public abstract void DrawPreview();
        public abstract void DrawStatic();
        public abstract void DrawEdit();
        public abstract Point GetCenterPoint();
        public abstract Point GetCenterPoint2();
        public abstract string GetText();
        public abstract void SetText(string text);
        public abstract bool Add(DrawingObject drawingObject);
        public abstract bool Remove(DrawingObject drawingObject);
        protected DrawingState state;
        
        public DrawingState drawingState
        {
            get
            {
                return this.state;
            }
        }

        public DrawingObject()
        {
            guid = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance());
        }

        public virtual void ChangeState (DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
            Notify();
        }

        public virtual void Selected()
        {
            this.state.Selected(this);
        }

        public virtual void Deselected()
        {
            this.state.Deselected(this);
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }
    }
}
