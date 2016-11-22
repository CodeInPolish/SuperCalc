using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class cos : TrigonoHelper
    {
        public override string Name { get { return "cos"; } }

        public override double Execute(params string[] args)
        {
            return evaluate(DigestInput(args));
        }

        private static double evaluate(double angle)
        {
            return Math.Cos(RadiansToDegree(angle));
        }

    }
}
