using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class derive : PolynomHelper
    {
        public new string Name { get { return "derive"; } }

        private double evaluate(double[] coeffs, double[] powers, double derive_at)
        {
            double derive = 0;

            for (int i = 0; i < coeffs.Length; i++)
            {
                derive += Math.Pow(derive_at, powers[i]-1) * coeffs[i]*powers[i];
            }

            return derive;
        }

        private static Tuple<double[], double[], double> DigestInput(string[] args)
        {
            if (args.Count() != 2)
                throw new ArgumentException("2 Arguments required");

            double eval_at = ConvertToDouble(args[1]);
            Tuple<double[], double[]> data = ConvertStringPolyToCoeffs(args[0]);

            return new Tuple<double[], double[], double>(data.Item1, data.Item2, eval_at);
        }

        public override double Execute(string[] args)
        {
            double result;
            try
            {
                Tuple<double[], double[], double> data = DigestInput(args);
                result = evaluate(data.Item1, data.Item2, data.Item3);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("2 Arguments required");
            }

            return result;
        }
    }
}

