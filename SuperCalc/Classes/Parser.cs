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
            string[] args = digestedInput.Item2;


            foreach (var item in args)
            {
                Console.WriteLine(item);
            }

            Type command = ReturnCommand(cmdName);
            ExecuteMethod(command, cmdName, digestedInput.Item2);
            return null;
       }

        private static Assembly LoadLib()
        {
            Assembly lib = Assembly.LoadFrom(@"D:\OneDrive for Business\Visual Studio Projects\Labos\SuperCalcLibs\SuperCalcLibs\bin\Debug\SuperCalcLibs.dll");
            return lib;
        }

        private static Tuple<string, string[]> DigestInput(string input)
        {
            string[] array = input.Split(' ');
            string cmd = array[0];
            string[] args = array.Skip(1).ToArray();

            Tuple<string, string[]> myTuple = new Tuple<string, string[]>(cmd, array);

            return myTuple;
        }

        private static  Type ReturnCommand (string cmdName)
        {
            Type obj = SeachClass(LoadLib(), cmdName);

            if (obj == null)
                Console.WriteLine("{0} is not recognized command", cmdName);                

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

        private static void ExecuteMethod(Type command, string methodName, string[] args)
        {
            MethodInfo executeMethod = command.GetMethod("Execute");
            string[] array = args[0].Split(';');
            double[] polynom = { } ;

            for (int i = 0; i < array.Count(); i++)
            {
                //polynom[i] = Convert.ToDouble(array[i]);
            }

            //double x = Convert.ToDouble(args[1]);
            object[] parameters = { polynom, 1 };
            Console.WriteLine(executeMethod.Invoke(null, parameters));
        }
    }
}
