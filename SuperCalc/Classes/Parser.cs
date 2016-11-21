using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Parser
    {
        public static string Parse(string input, string[] inputToIgnore)
        {
            if (!inputToIgnore.Contains(input.ToUpper())) 
            {
                var digestedInput = DigestInput(input);
                string cmdName = digestedInput.Item1;
                string[] args = digestedInput.Item2;

                return ExecuteMethod(cmdName, args); // ExecuteMethod return a message (string) 
                                                     //that is either data or an exception message
            }

            return "";
       }

       //Loads a List of assembly from a folder
        private static List<Assembly> LoadLib()
        {
            string[] files = Directory.GetFiles(@"C:\Library", "*.dll"); //returns the entire filepath to all .dll files inside directory
            List<Assembly> assemblyList = new List<Assembly>();

            foreach (string assemblyFile in files)
            {
                assemblyList.Add(Assembly.LoadFile(assemblyFile)); // Adding the loaded assembly from file to a list
            }

            return assemblyList;
        }

        //Splits the command name and arguments
        private static Tuple<string, string[]> DigestInput(string input)
        {
            string[] array = input.Split(' ');

            return new Tuple<string, string[]>(array[0], array.Skip(1).ToArray()); //Tuple( commandName, arguments)
        }

        //Returns a Class from the loaded assemblies, given its name
        private static  Type ReturnCommand (string cmdName)
        {
            Type obj = SearchClass(LoadLib(), cmdName); 

            if (obj == null)
                Console.WriteLine("{0} is not a recognized command", cmdName);                

            return obj;
        }
         
        //Searches in allAssembly for a class that matches the cmdName
        private static Type SearchClass (List<Assembly> allAssembly, string cmdName)
        {
            foreach (Assembly assembly in allAssembly)
            {
                foreach (Type t in assembly.GetTypes())
                {
                    if (t.IsClass && typeof(Computer.Computer).IsAssignableFrom(t) && t.Name.ToLower() == cmdName)
                    // t has to be a class, t has to have a Computer.Computer Interface
                    // t's name has to match the command name
                    {
                        return t;
                    }
                }
            }            

            return null; //return a null object if there is no match
        }

        //Instatiates a class and calls it's Execute() method
        private static string ExecuteMethod(string cmdName, string[] args)
        {
            string result = "";
            try 
            {
                Type commandClass = ReturnCommand(cmdName);
                Computer.Computer commandObj = (Computer.Computer)Activator.CreateInstance(commandClass);
                result = commandObj.Execute(args).ToString();
            }
            catch(Exception e)
            {
                result = e.Message;
            }

            return result;
            
        }
    }
}
