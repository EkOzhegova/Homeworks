using System;

namespace hw6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите абсциссу:");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ординату:");
            var y = double.Parse(Console.ReadLine());

            Console.WriteLine("Принадлежит ли точка области?" + IsPointInArea(x, y));

            Console.ReadKey();
        }
        static bool IsPointInArea(double x, double y)
        {
            return (x >= 2 && y >= 0 || x >= 1 && y <= -1);
        }
    }
}
