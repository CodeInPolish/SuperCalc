﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    class div : BasicMathHelper
    {
        string name { get { return "div"; } }

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
                    throw new Exception("Division by zero impossible");
                else
                {
                    result = result / i;
                }
            }
            return result;
        }
    }
}