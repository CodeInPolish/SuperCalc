using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class tan : Computer.Command
    {
        string name { get { return "tan"; } }

        public override double Execute(params string[] args)
        {
            return evaluate(DigestInput(args));
        }

        private static double evaluate(double angle)
        {
            return Math.Tan(angle * Math.PI / 180);
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
