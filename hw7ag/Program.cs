using System;

namespace HW7_again
{
    class Program
    {
        static void Main()
        {
            
            Console.WriteLine("Введите значение X:");
           double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Значение функции равно" + GetValueOfFunction(x));

            Console.ReadKey();

        }
        static double GetValueOfFunction ( double x)
        {
            if (x < -1)
            return 1;

            if (x >= -1 && x <= 1)
                return -x;

            else
                return -1;
           
        }
    }
}