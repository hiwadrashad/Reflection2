using Reflection2.LIB.Desgin_Patterns;
using Reflection2.LIB.Interfaces;
using Reflection2.LIB.Methods;
using System;
using System.Linq;
using System.Threading;

namespace Reflection2
{
    public class Program
    {
        private readonly IPreconfiguration _preconfiguration;
        private readonly ILogic _logic;
        public Program(IPreconfiguration preconfiguration, ILogic logic)
        {
            this._preconfiguration = preconfiguration;
            this._logic = logic;
        }
        static void Main(string[] args)
        {
            Thread.Sleep(10000);
            Console.WriteLine("=============================== reflection assembly object metadata ======================================");
            Console.WriteLine("\n");
            Console.WriteLine("Load in dll file as assembly object at run time");
            Console.WriteLine("\n");
            Reflection2.LIB.Methods.Preconfiguration preconfiguration = new Preconfiguration();
            Console.WriteLine("Iterate on all types");
            Console.WriteLine("\n");
            Reflection2.LIB.Methods.Logic Logic = new LIB.Methods.Logic();
            var types = preconfiguration.LoadAssembly();
            Logic.GetData(types);

            Console.WriteLine("\n");
            Console.WriteLine("=============================== reflection assembly object metadata ======================================");
            Console.WriteLine("\n");
            Console.WriteLine("create object from type");
            Console.WriteLine("\n");
            Console.WriteLine("Get all methods from type and invoke this with the previously created instance");
            Console.WriteLine("\n");
            Console.WriteLine("Commented out code is code which would be the dynamically added default value");
            Console.WriteLine("Problem is that no value can be given when invoked because the type is set at run time");
            Console.WriteLine("'Thats why a statically chosen value of null is chosen for a highest probability working code");
            Console.WriteLine("\n");
            Console.WriteLine("==========================================================");
            Logic.AssignData(types);
        }
    }
}
