using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public interface IFilter
    {
        ParameterInfo[] GetParametersInfo();
        Photo Process(Photo original, double[] parameters);
    }
}
