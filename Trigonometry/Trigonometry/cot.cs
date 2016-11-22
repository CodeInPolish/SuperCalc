using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class cot : TrigonoHelper
    {
        public override string Name { get { return "cot"; } }

        public override string Help
        {
            get
            {
                return "Compute the cotangent of the given angle (in degree)\nCalling method example: cot 15";
            }
        }

        public override double Execute(params string[] args)
        {
            return evaluate(DigestInput(args));
        }

        private static double evaluate(double angle)
        {
            return Math.Tan(RadiansToDegree(90-angle));
        }
    }
}
