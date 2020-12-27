using System;

namespace hw62
{
    class Program
    {
        static void Main()
        {


            var n = Program.delenie("n");

            Console.WriteLine(n);
            Console.ReadKey();
        }

        public static bool delenie(string x)
        {
            Console.WriteLine("Введите число " + x);
            var n = int.Parse(Console.ReadLine());
            return (n % 5 == 0 || n % 7 == 0);
        }

    }
}





