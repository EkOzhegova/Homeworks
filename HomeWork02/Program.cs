using System;

namespace HomeWork02
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите четырехзначное число: ");
            var number = int.Parse(Console.ReadLine());

            int a, b, c, d, result;
            a = number % 10;
            b = (number % 100 - number % 10) / 10;
            c = (number % 1000 - number % 100) / 100;
            d = (number / 1000);
            result = a * 1000 + b * 100 + c * 10 + d;
            Console.WriteLine($"Полученное число: " + result);
            Console.ReadKey();

        }
    }
}
