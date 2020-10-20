using System;

namespace homework03
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите значение x");
            var x = double.Parse(Console.ReadLine());

            var y = F(x);

            Console.WriteLine("f(x) = " + y);
            Console.ReadKey();
        }

        static double F(double x)
        {
            return 1 + Math.Sqrt((x * x - 1) / (x * x + 1));
        }
    }
}