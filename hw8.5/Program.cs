using System;

namespace hw8_5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите число m:");
            var m = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число n:");
            var n = int.Parse(Console.ReadLine());

            if (0 < m && 0 < n)
            {
                for (int i = 1; i <= (m * n); i++)
                {
                    if (i % m == 0 && i % n == 0)
                    {
                        Console.Write(i.ToString() + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Введенные значения некорректны");
            }

            Console.ReadKey();
        }
    }
}