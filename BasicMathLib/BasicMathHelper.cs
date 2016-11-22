using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    public class BasicMathHelper : Computer.Command
    {
        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override double Execute(params string[] args)
        {
            throw new NotImplementedException();
        }

        public static double[] ConvertToDouble(string[] args)
        {

            if (args.Count() < 2)
                throw new ArgumentException("At least 2 arguments required");

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