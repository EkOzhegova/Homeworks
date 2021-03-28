using System;

namespace BookLibraryLibrary
{
    public class Reader
    {
        public string Name;
        public string Surname;
        public int LibraryCardNumber;
        public string TakenLiterature;
        public DateTime DateOfIssue;
        public TimeSpan AmountOfDays;
        public DateTime ReturnDate;
        public double PiedgeAmount;

        public Reader(string name, string surname, int cardNumber)
        {
            Name = name;
            Surname = surname;
            LibraryCardNumber = cardNumber;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";

        }

        public void PrintInfo()
        {
            Console.WriteLine(this);

            Console.WriteLine($"Номер читательского билета: {LibraryCardNumber}. Список названий взятой литературы: {TakenLiterature}. Дата выдачи: {DateOfIssue.ToShortDateString()}. Срок выдачи: {AmountOfDays.ToString("%d")}. Дата планируемого возвращения: {ReturnDate.ToShortDateString()}. Сумма залога: {PiedgeAmount}.");
        }
    }
}