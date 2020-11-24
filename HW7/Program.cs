using System;

namespace HW7
{
    class Program
    {
        static void Main()
        {
            double x, function;
            Console.WriteLine("Введите значение X:");
            x = double.Parse(Console.ReadLine());
            if (x < -1)
            {
                function = 1;
                Console.WriteLine("Значение функции F(x) равно" + function);
            }
            else
                if (x >= -1 && x <= 1)
            {
                function = -x;
                Console.WriteLine("Значение функции F(x) равно" + function);
            }
            else
                if (x > 1)
            {
                function = -1;
                Console.WriteLine("Значение функции F(x) равно" + function);
            }

            Console.ReadKey();

        }
    }
}
