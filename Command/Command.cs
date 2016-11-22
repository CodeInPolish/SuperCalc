using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    public abstract class Command : Computer
    {
        public abstract string Name { get; }

        public abstract string Help { get; }

        public abstract double Execute(params string[] args);
    }
}
