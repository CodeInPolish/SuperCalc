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
            Assembly lib = Assembly.LoadFrom(@"C:\Library\Polynomial.dll");
            return lib;
        }

        private static Tuple<string, string[]> DigestInput(string input)
        {
            string[] array = input.Split(' ');

            return new Tuple<string, string[]>(array[0], array.Skip(1).ToArray());
        }

        private static  Type ReturnCommand (string cmdName)
        {
            Type obj = SearchClass(LoadLib(), cmdName);

            if (obj == null)
                Console.WriteLine("{0} is not a recognized command", cmdName);                

            return obj;
        }
         
        private static Type SearchClass (Assembly allAssembly, string cmdName)
        {
            foreach (Type t in allAssembly.GetTypes())
            {
                if(t.IsClass && typeof(Computer.Computer).IsAssignableFrom(t) && t.Name.ToLower() == cmdName)
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
                Type commandClass = ReturnCommand(cmdName);
                Computer.Computer commandObj = (Computer.Computer)Activator.CreateInstance(commandClass);
                Console.WriteLine(commandObj.Execute(args));
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            
        }
    }
}
