using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class sin
    {
        string name { get { return "sin"; } }

        public static string Execute(string[] args)
        {
            return evaluate(DigestInput(args)).ToString();
        }

        private static double evaluate(double angle)
        {
            return Math.Sin(angle * Math.PI / 180);
        }

        private static double DigestInput(string[] args)
        {
            if (args.Count() == 1)
            {
                return Convert.ToDouble(args[0]);
            }

            return 0.0;
        }
    }
}
