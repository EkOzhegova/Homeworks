using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTaskOne
{
    class Program
    {
        static int[] GetGetNegativeOddWitn1(int[] array)
        {
            return (int[])array
                .Where(a=> a < 0 && a % 2 != 0 && a.ToString().IndexOf("1") > 0)
                .OrderByDescending(a => a)
                .ToArray();
        }
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { -3456, 234, -17, 0, 1, 7, 11, 81, 60, -11, -227, -81, -23, -20 };

            Console.Write("Нажмите Enter для вывода информации на экран");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            int[] arr2 = GetGetNegativeOddWitn1(arr1);

            if (arr2.Count() > 0)
            {
                foreach (int i in arr2)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            else
                Console.WriteLine("Нет данных в выборке");

            Console.ReadKey();
        }
    }
}
