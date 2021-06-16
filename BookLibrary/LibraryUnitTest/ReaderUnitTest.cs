using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibraryLibrary;
using System.IO;

namespace ReaderUnitTest
{
    [TestClass]
    public class ReaderUnitTests
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var john = CreateTestCommodity();

            Assert.AreEqual("John", john.Name);
            Assert.AreEqual("Smith", john.Surname);
            Assert.AreEqual(239646, john.LibraryCardNumber);
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var john = CreateTestCommodity();
            Assert.AreEqual("John Smith", john.ToString());
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var john = CreateTestCommodity();
            var mary = new Reader("Mary", "Long", 245654);

            var consoleOut = new[]
            {
                "John Smith",
                $"Номер читательского билета: 239646. Список названий взятой литературы: 'Hobbit', 'LordOfTheRings', 'InvisibleMan'. Дата выдачи: 01.11.2020. Срок выдачи: 22. Дата планируемого возвращения: 23.11.2020. Сумма залога: 300." ,
                "Mary Long",
                $"Номер читательского билета: 245654. Список названий взятой литературы: 'TheGreatGatsby', '1984'. Дата выдачи: 05.11.2020. Срок выдачи: 7. Дата планируемого возвращения: 12.11.2020. Сумма залога: 200."
            };

            john.TakenLiterature = "'Hobbit', 'LordOfTheRings', 'InvisibleMan'";
            john.DateOfIssue = DateTime.Parse("01.11.2020");
            TimeSpan ts1 = new TimeSpan(22, 0, 0, 0);
            john.AmountOfDays = ts1;
            john.ReturnDate = john.DateOfIssue.AddDays(ts1.Days);
            john.PiedgeAmount = 300;
            mary.TakenLiterature = "'TheGreatGatsby', '1984'";
            mary.DateOfIssue = DateTime.Parse("05.11.2020");
            TimeSpan ts2 = new TimeSpan(7, 0, 0, 0);
            mary.AmountOfDays = ts2;
            mary.ReturnDate = mary.DateOfIssue.AddDays(ts2.Days);
            mary.PiedgeAmount = 200;

            TextWriter oldOut = Console.Out;
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            john.PrintInfo();
            mary.PrintInfo();

            Console.SetOut(oldOut);
            var outputArray = output.ToString().Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(4, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        private Reader CreateTestCommodity()
        {
            return new Reader("John", "Smith", 239646);
        }
    }
}