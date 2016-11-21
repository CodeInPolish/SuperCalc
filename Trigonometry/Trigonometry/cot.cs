using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    class cot
    {
        string name { get { return "cot"; } }

        public static string Execute(string[] args)
        {
            return evaluate(DigestInput(args)).ToString();
        }

        private static double evaluate(double angle)
        {
            return Math.Tan((180+angle) * Math.PI / 180);
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
