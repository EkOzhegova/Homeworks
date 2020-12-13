using System;

namespace hw8_3
{
    class Program
    {
        static void Main()
        {
            double mult = 1;
            int count = 0;

            Console.WriteLine("Введите последовательность неотрицательных чисел (0 завершает ввод):");

            while (true)
            {
                bool isParsed = double.TryParse(Console.ReadLine(), out double val);
                if (isParsed)
                {
                    if (val > 0)
                    {
                        count++;
                        mult *= val;
                    }
                    else if (val == 0)
                    {
                     
                        Console.WriteLine();
                        break;
                    }
                }
            }

            double pow = 1.0 / count;

            double result = Math.Pow(mult, pow);
            Console.WriteLine($"Среднее геометрическое =  {result}");
        }

    }
}