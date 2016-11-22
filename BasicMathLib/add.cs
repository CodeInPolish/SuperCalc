using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    class add : BasicMathHelper
    {
        public override string Name { get { return "add"; } }

        string Help { get { return "help"; } }

        public override double Execute(params string[] args)
        {
            return evaluate(ConvertToDouble(args));
        }

        private double evaluate(double[] args)
        {

            double result = 0;

            foreach (double i in args)
            {
                result += i;
            }
            return result;
        }
    }
}