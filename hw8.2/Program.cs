using System;

namespace hw8_2
{
    class Program
    {
        static void Main()
        {
            int k;


            while (true)
            {
                Console.WriteLine("Введите количество сданных экзаменов: ");

                if (!int.TryParse(Console.ReadLine(), out k))
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }

                if (k < 0)
                {
                    Console.WriteLine("Число должно быть неотрицательным\n");
                    continue;
                }
                else
                {
                    int result = Avg(k);
                    Console.WriteLine($"получанное число " + result);
                }
                break;

            }


            Console.WriteLine();

        }
        static int Avg(int k)
        {
            int sum = 0; int i = 1; int result = 0; int mark = 0;
           
                 while (i <= k)
                  {
                   Console.WriteLine("Введите оценку за экзамен: ");
                
                    if (!int.TryParse(Console.ReadLine(), out mark))
                    {
                        Console.WriteLine("Ошибка ввода, введите оценку заново");
                        continue;    
                    }
                
                    if (mark < 0 || mark > 100) 
                    {
                        Console.WriteLine("Оценка должна быть от 0 до 100, введите оценку еще раз");
                            continue;
                    }
                
                    else   
                         sum = sum + mark;
                         result = sum/k;
                         i++;
                     continue;

                  }
                return result;

        }
    }
}