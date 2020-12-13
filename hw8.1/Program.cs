using System;

namespace hw8_1
{
    class Program
    {
        static void Main()
        {
            int n;
          

            while (true)
            {
                Console.WriteLine("Введите число: ");

                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }

                if (n < 0)
                {
                    Console.WriteLine("Число должно быть неотрицательным\n");
                    continue;
                }
                else
                {
                    int result = Count(n);
                    Console.WriteLine($"получанное число: " + result);
                }
                break;
                
                }


            Console.WriteLine();
            Console.ReadKey();
        }
        static int Count(int n)
        {
            int Term = 0; int i = 0; int result = 0;
            while (i <= n)
            {
                Term = (n + i) * (n + i);
                result = result + Term;
                i++; 
               
                continue; 
                
            }
            return result; 
           
    }
        }
}