using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Parser
    {
        public static Command Parse(string input)
        {
            string[] array = input.Split(' ');
            Command newCommand = new Command(array);
            return newCommand;
        }
    }
}
