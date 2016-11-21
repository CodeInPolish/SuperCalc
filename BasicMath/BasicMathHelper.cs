using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    public class BasicMathHelper : Computer.Command
    {
        public override double Execute(params string[] args)
        {
            throw new NotImplementedException();
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
            catch (FormatException)
            {
                throw new ArgumentException("One or more of the arguments is not a number");
            }

            return result;
        }
    }
}
