using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;

namespace SuperCalcLibs
{
    public class Eval : Command.Command
    {
        public new string Name { get { return "eval"; } }

        private double evaluate(double[] coeffs, double eval_at)
        {
            double eval = 0;

            foreach (double coeff in coeffs)
            {
                eval = coeff * eval_at + eval;
            }

            return eval;
        }

        private static Tuple<double[], double> DigestInput(string[] args)
        {
            if (args.Count() != 2)
                throw new ArgumentException("2 Arguments required");

            double eval_at = 0.0;
            string[] stringPolynom = args[0].Split(';');
            double[] coeffs = new double[stringPolynom.Count()];

            try 
            {
                eval_at  = Convert.ToDouble(Convert.ToInt16(args[1]));

                for (int i = 0; i < stringPolynom.Count(); i++)
                {
                    coeffs[i] = Convert.ToDouble(stringPolynom[i]);
                }
            }
            catch(FormatException)
            {
                throw new ArgumentException("One or more arguments are invalid.");
            }
            catch(ArgumentException ex)
            {
                throw ex;
            }

            return new Tuple<double[], double> (coeffs, eval_at);
        }

        public override double Execute(string[] args)
        {
            double result;
            try
            {
                Tuple<double[], double> data = DigestInput(args);
                result = evaluate(data.Item1, data.Item2);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("2 Arguments required");
            }

            return result;
        }
    }
}
