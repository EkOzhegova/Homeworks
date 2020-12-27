using System;
using System.Linq;

namespace Example_2
{
    class Program
    {
        static void Main()
        {
           
            Console.WriteLine("Введите текст заглавными буквами: ");
            string x = Console.ReadLine();


            string result = translit(x);

            Console.WriteLine($"Полученный текст: " + result);

            Console.ReadKey();
        }


        private static string translit(string x)
        {
            string result = string.Empty;

            for (int i = 0; i < x.Length; i++)
            {
                string xPart = x.Substring(i, 1);
                string yPart = xPart;

                switch (xPart)
                {
                    case "A":
                        yPart = "8";
                        break;
                    case "B":
                        yPart = "8";
                        break;
                    case "C":
                        yPart = "(";
                        break;
                    case "D":
                        yPart = "|)";
                        break;
                    case "E":
                        yPart = "3";
                        break;
                    case "F":
                        yPart = "|=";
                        break;
                    case "G":
                        yPart = "6";
                        break;
                    case "H":
                        yPart = " |-|";
                        break;
                    case "I":
                        yPart = "!";
                        break;
                    case "J":
                        yPart = ")";
                        break;
                    case "K":
                        yPart = "|<";
                        break;
                    case "L":
                        yPart = "1";
                        break;
                    case "M":
                        yPart = "|\\/|";
                        break;
                    case "N":
                        yPart = "|\\|";
                        break;
                    case "O":
                        yPart = "0";
                        break;
                    case "P":
                        yPart = "|>";
                        break;
                    case "Q":
                        yPart = "9";
                        break;
                    case "R":
                        yPart = "|2";
                        break;
                    case "S":
                        yPart = "5";
                        break;
                    case "T":
                        yPart = "7";
                        break;
                    case "U":
                        yPart = "|_|";
                        break;
                    case "V":
                        yPart = "\\/";
                        break;
                    case "W":
                        yPart = "\\/\\/";
                        break;
                    case "X":
                        yPart = "><";
                        break;
                    case "Y":
                        yPart = "'/";
                        break;
                    case "Z":
                        yPart = "2";
                        break;

                }
                result = result + yPart;
            }

            return result;
        }
    }
}
