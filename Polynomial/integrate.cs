using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class integrate : PolynomHelper
    {
        public override string Name { get { return "integrate"; } }

        public override string Help
        {
            get
            {
                return "You can write : integrate 2x^3+6x^2+3x+8 0 2 \nIt compute the integrate of the polynome from 0 to 2";
            }
        }

        private double evaluate(double[] coeffs, double[] powers, double integrate_from, double integrate_to)
        {
            double integrate = 0;

            for (int i = 0; i < coeffs.Length; i++)
            {
                integrate += (Math.Pow(integrate_to, powers[i] + 1) - Math.Pow(integrate_from, powers[i] + 1)) * coeffs[i] / (powers[i]+1);
            }

            return integrate;
        }

        private static Tuple<double[], double[], double, double> DigestInput(string[] args)
        {
            if (args.Count() != 3)
                throw new ArgumentException("3 Arguments required");

            double eval_at = ConvertToDouble(args[1]);
            double eval_to = ConvertToDouble(args[2]);
            Tuple<double[], double[]> data = ConvertStringPolyToCoeffs(args[0]);

            return new Tuple<double[], double[], double, double>(data.Item1, data.Item2, eval_at, eval_to);
        }

        public override double Execute(params string[] args)
        {
            double result;
            try
            {
                Tuple<double[], double[], double, double> data = DigestInput(args);
                result = evaluate(data.Item1, data.Item2, data.Item3, data.Item4);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("3 Arguments required");
            }

            return result;
        }
    }
}
