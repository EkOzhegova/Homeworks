using System;

namespace exam_1task
{
    class Program
    {
        static void Main()
        {
            int n;
            

            while (true)
            {
                Console.WriteLine("Введите натуральное число:\n");
               
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }

                if (n <= 0)
                {
                    Console.WriteLine("Число должно быть положительным\n");
                    continue;
                }
                else
                {
                  Console.WriteLine( $"\nПростые делители числа {n}:\n");
                  FindDeviders(n);
                    
                }
                break;
            }
            Console.ReadKey();
        }
        static void FindDeviders(int inputnumber) // находит все делители числа (кроме единицы) и проверяет каждый на простоту
        {
            for (int i = 2; i <= inputnumber; i++)
            {
                if (inputnumber % i == 0 && IsDeviderPrime(i))
                {
                    Console.Write($"{i};");
                }
            }
        }
        static bool IsDeviderPrime( int i) //проверка числа на простоту (от двух до квадратного корня из этого числа)
        {
            for (int j = 2; j <= (int)Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    return false;                  
                }
            }
            return true;
        }
    }
}
