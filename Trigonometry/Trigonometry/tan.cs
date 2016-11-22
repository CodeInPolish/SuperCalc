using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class tan : TrigonoHelper
    {
        public override string Name { get { return "tan"; } }

        public override string Help
        {
            get
            {
                return "Compute the tangent of the given angle (in degree)\nCalling method example: tan 15";
            }
        }

        public override double Execute(params string[] args)
        {
            return evaluate(DigestInput(args));
        }

        private static double evaluate(double angle)
        {
            return Math.Tan(RadiansToDegree(angle));
        }

    }
}
