using Reflection2.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Desgin_Patterns
{
    public class ServiceLocator : IServiceLocator
    {
        public Dictionary<object, object> servicecontainer = null;
        public ServiceLocator()
        {
            servicecontainer = new Dictionary<object, object>();
        }

        public void AddService<T,A>(T InterfaceType, A ServiceType)
        {

            var ServiceInstance = Activator.CreateInstance(ServiceType as Type);
            if (servicecontainer == null || servicecontainer.Count == 0)
            {
                servicecontainer = new Dictionary<object, object>();
            }
            servicecontainer.Add(InterfaceType, ServiceInstance);
        }
        public T GetService<T,A>()
        {
            try
            {
                return (T)servicecontainer[typeof(A)];
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }
}
