using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Parser
    {
        public static string[] Parse(string cmd)
        {
            string[] args = cmd.Split(' ');
            return args;

        }
    }
}
