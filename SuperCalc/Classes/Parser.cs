using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    public class Parser
    {

        private List<Assembly> assemblies = new List<Assembly>();

        public Parser(params string[] args)
        {
            string folderPath = args[0];
            string filter = args[1];
            assemblies = LoadLib(folderPath, filter);
        }

        public string Parse(string input, string[] inputToIgnore)
        {
            if (!inputToIgnore.Contains(input.ToUpper())) 
            {
                var digestedInput = DigestInput(input);
                string cmdName = digestedInput.Item1;
                string[] args = digestedInput.Item2;

                return ExecuteMethod(cmdName, args); // ExecuteMethod return a message (string) 
                                                     //that is either data or an exception message
            }
            else 
            {
                if (input.ToUpper() == "LISTALL")
                    ListAllCommands();
            }

            return "";
       }

       //Loads a List of assemblies from a folder
        private List<Assembly> LoadLib(params string[] args)
        {
            string folderPath = args[0];
            string filter = args[1];
            string[] files = Directory.GetFiles(folderPath, filter); //returns the entire filepath to all .dll files inside directory
            List<Assembly> assemblyList = new List<Assembly>();

            foreach (string assemblyFile in files)
            {
                assemblyList.Add(Assembly.LoadFile(assemblyFile)); // Adding the loaded assembly from file to a list
            }

            return assemblyList;
        }

        //Splits the command name and arguments
        private Tuple<string, string[]> DigestInput(string input)
        {
            string[] array = input.Split(' ');

            return new Tuple<string, string[]>(array[0], array.Skip(1).ToArray()); //Tuple( commandName, arguments)
        }

        private string ListAllCommands()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type t in assembly.GetTypes())
                {
                    if(t.IsClass && typeof(Computer.Computer).IsAssignableFrom(t))
                    {
                        Computer.Command commandObj = (Computer.Command)Activator.CreateInstance(t);
                        try 
                        { 
                            sb.Append(commandObj.Name);
                        }
                        catch(NotImplementedException) { continue; } //Continue the loop if Name is not implemented
                    }
                }
            }

            return sb.ToString();
        }

        //Returns a Class from the loaded assemblies, given its name
        private Type ReturnCommand (string cmdName)
        {
            Type obj = SearchClass(assemblies, cmdName);

            if (obj == null)
                throw new ArgumentException(cmdName + " is not a recognized command");                

            return obj;
        }
         
        //Searches in allAssembly for a class that matches the cmdName
        private Type SearchClass (List<Assembly> allAssembly, string cmdName)
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
        private string ExecuteMethod(string cmdName, string[] args)
        {
            string result = "";
            try 
            {
                Type commandClass = ReturnCommand(cmdName);
                Computer.Command commandObj = (Computer.Command)Activator.CreateInstance(commandClass);
                if (args.Count() > 0 && args[0] == "-h")
                    result = commandObj.Help;
                else
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
