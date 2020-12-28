using System;
using System.Linq;

namespace task8_4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите натуральное число");
            int[] sorted; int[] original;
            
            while (true)
            {
                var input = Console.ReadLine();
                int number;

                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }
                
                else
                    number = int.Parse(input);


                int lengthofnumber = (int)(Math.Floor(Math.Log10(number) + 1));

                int[] allnumbers = new int[lengthofnumber];

                for (int i = lengthofnumber - 1; i >= 0; i--)
                {
                    int tempo = (int)(number / (Math.Pow(10, i)) % 10);
                    allnumbers[lengthofnumber - i - 1] = tempo;

                }
                int[] newarray = allnumbers.Distinct().ToArray();
                sorted = newarray;
                original = allnumbers;

                if (lengthofnumber > newarray.Count())
                {
                    Console.WriteLine("Введите число с разными цифрами");
                    continue;
                }
                else
                    break;


            }
            Array.Sort(sorted);

            for (int i = 0; i < original.Count(); i++)
            {
                if (original[i] == sorted[0])
                {
                    Console.WriteLine($"Минимальное значение - число {sorted[0]}, которое занимает  {i + 1} позицию");
                    break;
                }
            }
            Console.ReadKey();

        }


    }
}
