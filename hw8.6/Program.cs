using System;

namespace homework8_6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите требуемый вес: ");
            int m = int.Parse(Console.ReadLine());

            int firstWeight = 1;
            int secondWeight = 2;
            int thirdWeight = 5;
            int count = 0;

            for (int i = 0; i <= m; i++)
                for (int j = 0; j <= m; j++)
                    for (int k = 0; k <= m; k++)
                    {
                        if ((i * firstWeight) + (j * secondWeight) + (k * thirdWeight) == m)
                        {
                            for (int l = 0; l < i; l++)
                                Console.Write(firstWeight.ToString() + " ");

                            for (int l = 0; l < j; l++)
                                Console.Write(secondWeight.ToString() + " ");

                            for (int l = 0; l < k; l++)
                                Console.Write(thirdWeight.ToString() + " ");

                            count++;
                            Console.WriteLine();
                        }
                    }

            Console.WriteLine("Итого вариантов: " + count.ToString());

            Console.ReadKey();

        }
    }
}