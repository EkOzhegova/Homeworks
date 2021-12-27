using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoEnhancer;

namespace Profiler
{
    class Program
    {
        static void Main()
        {
            var simpleFactory = new SimpleParametersFactory<LighteningParameters>();
            TestLighteningParameters(values => simpleFactory.CreateParameters(values), 500000);

            var advancedFactory = new AdvancedParametersFactory<LighteningParameters>();
            TestLighteningParameters(values => advancedFactory.CreateParameters(values), 500000);

            TestLighteningParameters(values => new LighteningParameters() { Coefficent = values[0] }, 500000);

            Console.ReadKey();
        }

        static void TestLighteningParameters(Func<double[], LighteningParameters> method, int n)
        {
            var values = new double[] { 1 };
            var parameters = new LighteningParameters();

            method(values);

            var watch = new Stopwatch();
            watch.Start();

            for (var i = 0; i < n; i++)
                method(values);

            watch.Stop();

            Console.WriteLine(1000.0 * watch.ElapsedMilliseconds / n);
        }
    }
}
