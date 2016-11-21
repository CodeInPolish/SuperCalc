using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    public abstract class Command : Computer
    {
        public string Name { get; }

        public abstract double Execute(string[] args);
    }
}
