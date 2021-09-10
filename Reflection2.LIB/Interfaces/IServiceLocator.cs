using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Interfaces
{
    public interface IServiceLocator
    {
        void AddService<T, A>(T Interface, A Service);
        T GetService<T,A>();
    }
}
