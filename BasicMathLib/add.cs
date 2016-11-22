using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    class add : BasicMathHelper
    {
        string name { get { return "add"; } }

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