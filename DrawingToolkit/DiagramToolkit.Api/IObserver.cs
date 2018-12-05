using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Api
{
    public interface IObserver
    {
        void update(Observable observerable);
    }
}
