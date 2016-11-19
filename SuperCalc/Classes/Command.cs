using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Command
    {
        public string name;
        public string[] args;

        public void execute()
        {

        }

        public Command (string[] input)
        {
            name = input[0].ToUpper();
            args = input.Skip<string>(1).ToArray();
        }

        public Command()
        { }
    }
}
