using Reflection2.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Methods
{
    public class Preconfiguration : IPreconfiguration
    {
        public Type[] LoadAssembly()
        {
            string currentdirectory = Environment.CurrentDirectory;
            string relativepath = currentdirectory + @"\..\..\..\..\Reflection2.LIB\Dll's\ReflectThis.dll";
            var assembly = System.Reflection.Assembly.LoadFile(relativepath);
            Console.WriteLine("Get all types from assembly object");
            var types = assembly.GetTypes();
            return types;
        }
    }
}
