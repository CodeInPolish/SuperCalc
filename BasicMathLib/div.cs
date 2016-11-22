using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    class div : BasicMathHelper
    {
        public override string Name { get { return "div"; } }

        public override string Help
        {
            get
            {
                return "Successive division of elements separated by a space\nCalling method example: div 5 6 8";
            }
        }

        public override double Execute(params string[] args)
        {
            return evaluate(ConvertToDouble(args));
        }

        private double evaluate(double[] args)
        {

            double result = args[0];

            foreach (double i in args.Skip(1))
            {
                if (i == 0)
                    throw new Exception("Cannot divide by zero");
                else
                {
                    result = result / i;
                }
            }
            return result;
        }
    }
}
