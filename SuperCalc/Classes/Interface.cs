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
            AnalyseInput();
                      
        }

        private void Exit()
        {
            running = false;
            Console.WriteLine("Exiting");
        }

        private void AnalyseInput()
        {
            string cmd = Console.ReadLine();
            Command newCMD = Parser.Parse(cmd);
            if (newCMD.name == "EXIT")
                Exit();
            Console.WriteLine("{0} with args :", newCMD.name);
            foreach (string arg in newCMD.args)
            {
                Console.Write("{0}\n",arg);
            }
        }

    }
}
