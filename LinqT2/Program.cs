using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTaskTwo
{
    class Program
    {
        public struct Record
        {
            public int ClientID; // идентификационный номер клиента
            public int Year;     // год
            public int Month;    // номер месяца
            public int Duration; // продолжительность занятий в данном месяце данного года (в часах)
        }

        static void Main(string[] args)
        {
            Record[] Training = new Record[10];

            Training[0].ClientID = 123;
            Training[0].Year = 2020;
            Training[0].Month = 2;
            Training[0].Duration = 21;

            Training[1].ClientID = 123;
            Training[1].Year = 2020;
            Training[1].Month = 5;
            Training[1].Duration = 19;

            Training[2].ClientID = 123;
            Training[2].Year = 2021;
            Training[2].Month = 11;
            Training[2].Duration = 14;

            Training[3].ClientID = 123;
            Training[3].Year = 2021;
            Training[3].Month = 1;
            Training[3].Duration = 19;

            Training[4].ClientID = 123;
            Training[4].Year = 2021;
            Training[4].Month = 7;
            Training[4].Duration = 21;

            Training[5].ClientID = 321;
            Training[5].Year = 2020;
            Training[5].Month = 4;
            Training[5].Duration = 10;

            Training[6].ClientID = 321;
            Training[6].Year = 2020;
            Training[6].Month = 5;
            Training[6].Duration = 17;

            Training[7].ClientID = 321;
            Training[7].Year = 2021;
            Training[7].Month = 6;
            Training[7].Duration = 14;

            Training[8].ClientID = 321;
            Training[8].Year = 2021;
            Training[8].Month = 9;
            Training[8].Duration = 16;

            Training[9].ClientID = 321;
            Training[9].Year = 2021;
            Training[9].Month = 12;
            Training[9].Duration = 13;

            var lines = Training
                .GroupBy(r => new {r.ClientID, r.Year })
                .Select(g => (g.Key, g.Sum(d => d.Duration)))
                .OrderBy(r => r.Key.ClientID)
                .ThenBy(r => r.Key.Year);

            if (lines.Count() > 0)
            {
                Console.WriteLine("Занятия клиента по годам:");
                Console.WriteLine(" ");
                foreach (var line in lines)
                    Console.WriteLine($"Клиент № {line.Key.ClientID} провел {line.Item2} дней в {line.Key.Year} году");
            }
            else
                Console.WriteLine($"Информация отсутствует");

            Console.ReadKey();
        }
    }
}
