using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Interfaces
{
    public interface ILogic
    {
        void GetData(Type[] types);
        void AssignData(Type[] types);
    }
}
