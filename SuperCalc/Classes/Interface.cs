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
            string input = Console.ReadLine();

            if (input.ToUpper() == "EXIT")
                Exit();

            if(running)
                Parser.Parse(input);
        }

    }
}
