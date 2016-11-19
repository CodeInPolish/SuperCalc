using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Parser
    {
      
       public static string Parse(string input)
       {
            var digestedInput = DigestInput(input);
            string cmdName = digestedInput.Item1;
            ReturnCommand(cmdName);
            return null;
       }

        private static Assembly LoadLib()
        {
            Assembly lib = Assembly.LoadFrom(@"C:\SuperCalcLibs.dll");
            return lib;
        }

        private static Tuple<string, string[]> DigestInput(string input)
        {
            string[] array = input.Split(' ');
            string cmd = array[0];
            string[] args = array.Skip<string>(1).ToArray();
            Tuple<string, string[]> myTuple = new Tuple<string, string[]>(cmd, array);

            return myTuple;
        }

        private static  Type ReturnCommand (string cmdName)
        {
            Type obj = SeachClass(LoadLib(), cmdName);

            if (obj != null)
                Console.WriteLine(obj.Name);
            else
                Console.WriteLine("{0} is not recognized", cmdName);

            return obj;
        }

        private static Type SeachClass (Assembly allAssembly, string cmdName)
        {
            foreach (Type t in allAssembly.GetTypes())
            {
                if(t.IsClass && t.Name.ToLower() == cmdName)
                {
                    return t;
                }
            }

            return null;
        }
    }
}
