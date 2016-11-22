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
                    return ListAllCommands() + "\nUse the command : \"commandName -h\" to have a description of the command";
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
            List<string> sb = new List<string>();

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type t in assembly.GetTypes())
                {
                    if(t.IsClass && typeof(Computer.Computer).IsAssignableFrom(t))
                    {
                        try 
                        {
                            Computer.Command commandObj = (Computer.Command)Activator.CreateInstance(t);
                            sb.Add(commandObj.Name + "\n");
                        }
                        //Do nothing if Name is not implemented
                        // if Name is not implemented, it means it is not a command we can use
                        catch (NotImplementedException) {} 
                    }
                }
            }

            //Orders the list of string in an alphabetical order, then joins every string into one big string
            // then Trims the end of it, to contains no new line
            return String.Join("", sb.OrderBy(str => str)).TrimEnd(Environment.NewLine.ToCharArray());
        }

        //Returns a Class from the loaded assemblies, given its name
        private Type ReturnCommand (string cmdName)
        {
            Type obj = SearchClass(cmdName);

            if (obj == null)
                throw new ArgumentException(cmdName + " is not a recognized command");                

            return obj;
        }
         
        //Searches in allAssembly for a class that matches the cmdName
        private Type SearchClass (string cmdName)
        {
            foreach (Assembly assembly in assemblies)
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
