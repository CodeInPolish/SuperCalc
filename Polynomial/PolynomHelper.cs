using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Polynomial
{
    public class PolynomHelper : Computer.Command
    {

        public override double Execute(params string[] args)
        {
            throw new NotImplementedException();
        }

        public static Tuple<double[], double[]> ConvertStringPolyToCoeffs(string input)
        {
            string[] components = String.Join("+", Regex.Split(input, "(-)")).Split('+');

            // scinde le polynome en une série de terme
            List<string> termes = new List<string>();
            for (int i = 0; i < components.Count(); i++)
            {
                if (components[i] == "-")
                    components[i + 1] = '-' + components[i + 1];
                else
                    termes.Add(components[i]);
            }

            // pour chaque terme, en recherche son coef et sa puissance
            List<string> coeffs = new List<string>();
            List<string> expos = new List<string>();
            for (int i = 0; i < termes.Count(); i++)
            {
                int Xindex = termes[i].IndexOf("x");
                if (Xindex == 0)
                {
                    coeffs.Add("1");
                    if (Xindex == termes[i].Count() - 1)
                        expos.Add("1");
                    else
                        expos.Add(termes[i].Substring(Xindex + 2, termes[i].Count() - Xindex - 2));
                }
                else if (Xindex == termes[i].Count() - 1)
                {
                    if (termes[i].Substring(0, Xindex) == "-")
                        coeffs.Add("-1");
                    else
                        coeffs.Add(termes[i].Substring(0, Xindex));
                    expos.Add("1");
                }
                else if (Xindex == -1)
                {
                    expos.Add("0");
                    coeffs.Add(termes[i]);
                }
                else
                {
                    coeffs.Add(termes[i].Substring(0, Xindex));
                    expos.Add(termes[i].Substring(Xindex + 2, termes[i].Count() - Xindex - 2));
                }

            }

            return new Tuple<double[], double[]>(ConvertToDouble(coeffs.ToArray()), ConvertToDouble(expos.ToArray()));
        }

        public static double ConvertToDouble (string arg)
        {
            double result;

            try 
            {
                result = Convert.ToDouble(arg);
            }
            catch(FormatException)
            {
                throw new ArgumentException("Argument passed is not a number");
            }

            return result;
        }

        public static double[] ConvertToDouble(string[] args)
        {
            double[] result = new double[args.Count()];

            try
            {
                for (int i = 0; i < args.Count(); i++)
                {
                    result[i] = Convert.ToDouble(args[i]);
                }
            }
            catch(FormatException)
            {
                throw new ArgumentException("One or more of the arguments is not a number");
            }

            return result;
        }
    }

}
