using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class AdvancedParametersFactory<TParameters> : IParametersFactory<TParameters>
        where TParameters : IParameters, new()
    {
        static ParameterInfo[] description;
        static PropertyInfo[] properties;

        static AdvancedParametersFactory()
        {
            description = typeof(TParameters)
                .GetProperties()
                .Select(p => p.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(a => a.Length > 0)
                .SelectMany(a => a)
                .Cast<ParameterInfo>()
                .ToArray();

            properties = typeof(TParameters)
                .GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
        }

        public ParameterInfo[] GetDescription()
        {
            return description;
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();

            if (properties.Length != values.Length)
                throw new ArgumentException();

            for (var i = 0; i < values.Length; i++)
                properties[i].SetValue(parameters, values[i]);

            return parameters;
        }
    }
}
