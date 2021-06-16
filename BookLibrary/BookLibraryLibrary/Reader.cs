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

        public virtual void PrintInfo()
        {
            Console.WriteLine(this);

            Console.WriteLine($"Номер читательского билета: {LibraryCardNumber}. Список названий взятой литературы: {TakenLiterature}. Дата выдачи: {DateOfIssue.ToShortDateString()}. Срок выдачи: {AmountOfDays.ToString("%d")}. Дата планируемого возвращения: {ReturnDate.ToShortDateString()}. Сумма залога: {PiedgeAmount}.");
        }       
    }
    public class RegularReader : Reader
    {
        public DateTime EntryDate;
        public string Address;
        public string PhoneNumber;

        public RegularReader(string name, string surname, int cardNumber, string entryDate, string address, string phoneNumber) : base(name, surname, cardNumber)
        {
            EntryDate = DateTime.Parse(entryDate);
            Address = address;
            PhoneNumber = phoneNumber;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Дата записи в библиотеку: {EntryDate:d}. Адрес: {Address}. Телефон: {PhoneNumber}.");
        }
    }
    public class TemporaryReader : Reader
    {
        public DateTime ExpirationDate;
        public string DepartmentNames;

        public TemporaryReader(string name, string surname, int cardNumber, string expirationDate, string departmentNames) : base(name, surname, cardNumber)
        {
            ExpirationDate = DateTime.Parse(expirationDate);
            DepartmentNames = departmentNames;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Дата окончания допуска в библиотеку: {ExpirationDate:d}. Названия отделов, в которые разрешен допуск: {DepartmentNames}.");
        }
    }
    public class Visitor : Reader
    {
        public DateTime ArrivalTime;
        public DateTime LeavingTime;
        public string CertificateName;
        public int IDNumber;

        public Visitor(string name, string surname, int cardNumber, string arrivalTime, string leavingTime, string certificateName, int iDNumber) : base(name, surname, cardNumber)
        {
            ArrivalTime = DateTime.Parse(arrivalTime);
            LeavingTime = DateTime.Parse(leavingTime);
            CertificateName = certificateName;
            IDNumber = iDNumber;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Время прихода: {ArrivalTime.ToString("G")}. Время ухода: {LeavingTime.ToString("G")}. Название и номер удостоверения личности: {CertificateName} №{IDNumber}.");
        }
    }
}