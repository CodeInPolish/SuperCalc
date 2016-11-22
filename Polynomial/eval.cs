using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class eval : PolynomHelper
    {
        public override string Name { get { return "eval"; } }

        public override string Help
        {
            get
            {
                return "You can write : eval 2x^3+6x^2+3x+8 5 \nIt compute the polynome at x = 5 ";
            }
        }

        private double evaluate(double[] coeffs, double[] powers, double eval_at)
        {
            double eval = 0;

            for (int i = 0; i < coeffs.Length; i++)
            {
                eval += Math.Pow(eval_at, powers[i]) * coeffs[i];
            }

            return eval;
        }

        private static Tuple<double[], double[], double> DigestInput(string[] args)
        {
            if (args.Count() != 2)
                throw new ArgumentException("2 Arguments required");

            double eval_at = ConvertToDouble(args[1]);
            Tuple<double[], double[]> data = ConvertStringPolyToCoeffs(args[0]);

            return new Tuple<double[], double[], double> (data.Item1, data.Item2, eval_at);
        }

        public override double Execute(params string[] args)
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
