﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    public interface Computer
    {
        string Name { get; }

        double Execute(params string[] args);
    }
}
