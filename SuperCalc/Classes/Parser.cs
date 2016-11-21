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

        public static void Parse(string input)
        {
            var digestedInput = DigestInput(input);
            string cmdName = digestedInput.Item1;
            string[] args = digestedInput.Item2;

            ExecuteMethod(cmdName, digestedInput.Item2);
       }

        private static Assembly LoadLib()
        {
            Assembly lib = Assembly.LoadFrom(@"F:\ECAM\3BA\2E3040 - PROJET INFO\Travail2\SuperCalcLibs\SuperCalcLibs\bin\Debug\SuperCalcLibs.dll");
            return lib;
        }

        private static Tuple<string, string[]> DigestInput(string input)
        {
            string[] array = input.Split(' ');

            return new Tuple<string, string[]>(array[0], array.Skip(1).ToArray());
        }

        private static  Type ReturnCommand (string cmdName)
        {
            Type obj = SeachClass(LoadLib(), cmdName);

            if (obj == null)
                Console.WriteLine("{0} is not a recognized command", cmdName);                

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

        private static void ExecuteMethod(string cmdName, string[] args)
        {
            try 
            {
                Type command = ReturnCommand(cmdName);
                MethodInfo executeMethod = command.GetMethod("Execute");
                object[] parameters = { args };
                Console.WriteLine(executeMethod.Invoke(null, parameters));
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            
        }
    }
}
