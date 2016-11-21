using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    class addition : BasicMathHelper
    {
        string name { get { return "addition"; } }

        public override double Execute(params string[] args)
        {
            return evaluate(ConvertToDouble(args));
        }

        private double evaluate(double[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("minimum 2 required argument");

            return args.Sum();
        }
    }
}
