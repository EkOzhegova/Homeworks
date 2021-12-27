using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ParameterInfo : Attribute
    {
        public string Name;
        public double DefaultValue;
        public double MinValue;
        public double MaxValue;
        public double Increment;
    }
}
