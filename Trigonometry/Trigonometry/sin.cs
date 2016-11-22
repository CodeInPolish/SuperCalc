using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class sin : TrigonoHelper
    {
        public override string Name { get { return "sin"; } }

        public override string Help
        {
            get
            {
                return "Compute the sinus of the given angle (in degree)\nCalling method example: sin 15";
            }
        }

        public override double Execute(params string[] args)
        {
            return evaluate(DigestInput(args));
        }

        private static double evaluate(double angle)
        {
            return Math.Sin(RadiansToDegree(angle));
        }
    }
}
