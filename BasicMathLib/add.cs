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

        public override string Help
        {
            get
            {
                return "Successive addition of elements separated by a space";
            }
        }

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