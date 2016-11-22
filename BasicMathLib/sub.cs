using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    class sub : BasicMathHelper
    {
        public override string Name { get { return "sub"; } }

        public override double Execute(params string[] args)
        {
            return evaluate(ConvertToDouble(args));
        }

        private double evaluate(double[] args)
        {

            double result = args[0];
            foreach (double i in (args.Skip(1)))
            {
                result -= i;
            }
            return result;
        }
    }
}
