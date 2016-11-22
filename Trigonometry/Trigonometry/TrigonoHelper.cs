using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    public class TrigonoHelper : Computer.Command
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

        public static double RadiansToDegree(double radians)
        {
            return radians * Math.PI / 180;
        }

        public static double DigestInput(string[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException("1 Required argument");

            try
            {
                return Convert.ToDouble(args[0]);
            }
            catch(FormatException)
            {
                throw new ArgumentException("Given argument is not a number");
            }
        }
    }
}
