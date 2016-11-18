using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Interface
    {
        public bool running = true;

        public void StartMessage()
        {
            Console.WriteLine("Welcome message");
        }

        public void Display()
        {
            Console.Write(">>>");
            string cmd = Console.ReadLine();
            string[] args = Parser.Parse(cmd);
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }            
        }

        private void Exit()
        {

        }

    }
}
