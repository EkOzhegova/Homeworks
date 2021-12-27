﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class InclineParameters : IParameters
    {
        [ParameterInfo(Name = "Угол поворота в °", MinValue = 0,  MaxValue = 85, DefaultValue = 0, Increment = 5)]
        public double AngleInDegrees { get; set; }
    }
}
