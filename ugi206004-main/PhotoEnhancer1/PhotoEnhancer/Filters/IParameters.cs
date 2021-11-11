using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public interface IParameters
    {
        ParameterInfo[] GetDisciption();
        void SetValues(double[] values);
    }
}
