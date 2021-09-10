using Reflection2.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2.LIB.Logging
{
    public class Logging
    {
        public static void Logline(string Line)
        {
            string currentdirectory = Environment.CurrentDirectory;
            string relativepath = currentdirectory + @"\..\..\..\..\Reflection2.LIB\Logs\";
            File.AppendAllText(relativepath + "log.txt", Line + Environment.NewLine);
        }
    }
}
