using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Desgin_Patterns
{
    public class ServiceLocatorSingleton
    {
        private static ServiceLocator _serviceLocator;
        private ServiceLocatorSingleton()
        {

        }

        public static ServiceLocator GetServiceLocator()
        {
            if (_serviceLocator == null)
            {
                _serviceLocator = new ServiceLocator();
            }
            return _serviceLocator;
        }
    }
}
