using System;

namespace DigitsReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 4х-значное число.");
            string s = Console.ReadLine();
            char[] str = s.ToCharArray();
            string a;
            for (int i = str.Length - 1; i > -1; --i)
            {
                a = Convert.ToString(str[i]);
                Console.Write(a);
            }
            Console.ReadKey();
        }
    }
}
