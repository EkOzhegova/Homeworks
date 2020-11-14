using System;

namespace MathExp
{
    class Program
    {
        static void Main()
        {
            var result = Math.Round((Power(2, 3) + Power(3, 5) * Power(5, 7)), 7);
            Console.WriteLine($"Значение выражения равно: {result}");
            Console.ReadKey();
        }
        static double Power(int a, int b)
        {
            
            var sideres = Math.Exp(-Math.Sqrt(a + (Math.Pow(b, 2))));
            return sideres;
        }
    }
}
