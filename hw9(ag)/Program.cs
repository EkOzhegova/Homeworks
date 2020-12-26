using System;

namespace hw9
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите число n: ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = createArray(n);

            Console.WriteLine("\nИсходный массив:");
            printArray(numbers, n);

            changeArray(numbers, n);

            Console.WriteLine("\nИзмененный массив (п3):");
            printArray(numbers, n);

            Console.Write("\nВведите число m: ");
            int m = int.Parse(Console.ReadLine());

            int count = countM(numbers, n, m);

            Console.WriteLine("\nКоличество вхождений числа {0} в массив: {1}", m, count);

            int[] new_numbers = replaceNumbers(numbers, n);

            Console.WriteLine("\nОбработанный массив:");
            printArray(new_numbers, n);

        }
        static int[] createArray(int n)
        {

            double pi = Math.PI;

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = (int)Math.Floor(pi);
                pi -= array[i];
                pi *= 10;
            }

            return array;

        }

        static void printArray(int[] array, int n)
        {


            for (int i = 0; i < n / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0} ", array[10 * i + j]);
                }
                Console.WriteLine();
            }

            for (int j = 0; j < n - ((n / 10) * 10); j++)
            {
                Console.Write("{0} ", array[(n / 10) * 10 + j]);
            }
            Console.WriteLine();
        }


        static void changeArray(int[] array, int n)
        {
            for (int i = 0; i < n; i++)
            {
                array[i] = 9 - array[i];
            }
        }

        static int countM(int[] array, int n, int m)
        {
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] == m)
                {
                    count += 1;
                }
            }

            return count;
        }


        static int[] replaceNumbers(int[] array, int n)
        {

            int[] new_array = new int[n];

            for (int i = 0; i < n; i++)
            {
                new_array[i] = array[i] % 2;
            }

            return new_array;
        }
    }
}
