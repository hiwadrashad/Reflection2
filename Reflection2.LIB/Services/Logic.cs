using Reflection2.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Methods
{
    public class Logic : ILogic
    {
        public void GetData(Type[] types)
        {

            foreach (var item in types)
            {
                Console.WriteLine($"Type name: {item.FullName}");
                Reflection2.LIB.Logging.Logging.Logline($"Type name: {item.FullName}");
                if (item.GetMembers().Count() > 0)
                {
                    foreach (var item4 in item.GetMembers())
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Member name: {item4.Name}");
                        Reflection2.LIB.Logging.Logging.Logline($"Member name: {item4.Name}");
                        Console.WriteLine("\n");
                        Console.WriteLine($"Member type: {item4.MemberType}");
                        Reflection2.LIB.Logging.Logging.Logline($"Member type: {item4.MemberType}");
                        Console.WriteLine("\n");
                    }
                }
                if (item.GetMethods().Count() > 0)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Methods:");
                    Reflection2.LIB.Logging.Logging.Logline("Methods:");
                    foreach (var item2 in item.GetMethods())
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Method name: {item2.Name}");
                        Reflection2.LIB.Logging.Logging.Logline($"Method name: {item2.Name}");
                        Console.WriteLine("\n");
                        Console.WriteLine($"Return type : {item2.ReturnType.FullName}");
                        Reflection2.LIB.Logging.Logging.Logline($"Return type : {item2.ReturnType.FullName}");
                        Console.WriteLine("\n");
                        if (item2.GetParameters().Count() > 0)
                        {
                            foreach (var item3 in item2.GetParameters())
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine($"Parameters : {item3.ParameterType.FullName}");
                                Reflection2.LIB.Logging.Logging.Logline($"Parameters : {item3.ParameterType.FullName}");
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("\n");
                }
            }
        }

        public void AssignData(Type[] types)
        {
            if (types.Count() > 0)
            {
                foreach (var objectitem in types)
                {
                    Console.WriteLine("Activator used for generating instance");
                    Reflection2.LIB.Logging.Logging.Logline("Activator used for generating instance");
                    dynamic instance = Activator.CreateInstance(objectitem);

                    if (objectitem.GetMethods().Count() > 0)
                    {
                        foreach (var objectitem2 in objectitem.GetMethods())
                        {
                            var parameters = objectitem2.GetParameters();
                            if (parameters.Count() == 1)
                            {
                                var singleinputvaluetype = parameters.FirstOrDefault().ParameterType;

                                ///
                                ///<summary>
                                /// below is the adjusted code to make code owkr with highest possible probabilty
                                ///</summary>
                                ///

                                //var singleinputvalue = default(singleinputvaluetype);
                                object objectinstance = objectitem2.Invoke(instance, new dynamic[] { null });
                                //object objectinstance = objectitem2.Invoke(instance, new object[] { singleinputvalue });
                                Console.WriteLine("\n");
                                Console.WriteLine("one input method invoked");
                                Reflection2.LIB.Logging.Logging.Logline("one input method invoked");
                                Console.WriteLine("\n");
                            }
                        }
                    }
                }
            }
        }
    }
}
