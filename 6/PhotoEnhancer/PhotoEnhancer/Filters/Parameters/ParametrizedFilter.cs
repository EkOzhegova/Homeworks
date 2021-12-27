using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters: IParameters, new()
    {
        string name;

        IParametersFactory<TParameters> factory = new AdvancedParametersFactory<TParameters>();

        public ParametrizedFilter(string name)
        {
            this.name = name;
        }

        public ParameterInfo[] GetParametersInfo()
        {
            return factory.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = factory.CreateParameters(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, TParameters parameters);

        public override string ToString()
        {
            return name;
        }
    }
}
