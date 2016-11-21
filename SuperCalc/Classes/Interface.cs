using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Interface
    {
        public bool running = true; //Flag indicating that the Interface is running
        private string[] inputToIgnore = new string[1] {"EXIT"}; 

        //Display a message at start-up
        public void StartMessage()
        {
            Console.WriteLine("Welcome message");
        }

        //Controls the display, to be placed in a while(running) loop
        public void Display()
        {
            Console.Write(">>>");
            string message = AnalyseInput();
            Console.WriteLine(message);                     
        }

        //Executes the exit command
        private void Exit()
        {
            Console.WriteLine("... Press any key to exit ... (or ESC to cancel)");
            char pressedKey = Console.ReadKey(true).KeyChar; //true = Does not display the pressed key
            running = pressedKey == 27; //testing if the ESC key is pressed to cancel exit command
            //escaped = true;
        }

        //Reads input and calls the Parser
        private string AnalyseInput()
        {
            string input = Console.ReadLine();
            string message = "";

            if (input.ToUpper() == "EXIT")
                Exit();

            if(running) //if the console is running and we did not escape from the exit command
                message = Parser.Parse(input, inputToIgnore );

            //escaped = false;
            return message;
            
        }

    }
}
