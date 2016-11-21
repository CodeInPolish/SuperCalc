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
        private bool escaped = false;

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
            Console.WriteLine("... Press any key to exit ...");
            char pressedKey = Console.ReadKey(true).KeyChar; //true = Does not display the pressed key
            running = pressedKey == 27; //testing if the ESC key is pressed to cancel exit command
            escaped = true;
        }

        private void AnalyseInput()
        {
            string input = Console.ReadLine();

            if (input.ToUpper() == "EXIT")
                Exit();

            if(running && !escaped) //if the console is running and we did not escape from the exit command
                Parser.Parse(input);


            escaped = false;
            
        }

    }
}
