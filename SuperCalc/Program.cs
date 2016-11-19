using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface HI = new Interface();
            HI.StartMessage();
            while(HI.running)
            {
                HI.Display();
            }

            Console.ReadLine();
        }
    }
}
