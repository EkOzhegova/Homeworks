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

        [TestClass]
        public class RegularReaderUnitTest
        {
            [TestMethod]
            public void ConstructorRRTestMethod()
            {
                var john = GetTestRegularReader();
                Assert.AreEqual("21.12.2020", john.EntryDate.ToShortDateString());
                Assert.AreEqual("Baker Street 12", john.Address);
                Assert.AreEqual("+3122020", john.PhoneNumber);
            }

            [TestMethod]
            public void PrintInfoRRTestMethod()
            {
                var john = GetTestRegularReader();
                var lines = new[]
                {
                   "John Smith",
                   "Номер читательского билета: 239646. Список названий взятой литературы: 'Hobbit', 'LordOfTheRings', 'InvisibleMan'. Дата выдачи: 01.11.2020. Срок выдачи: 22. Дата планируемого возвращения: 23.11.2020. Сумма залога: 300.",
                   "Дата записи в библиотеку: 21.12.2020. Адрес: Baker Street 12. Телефон: +3122020."
                };

                john.TakenLiterature = "'Hobbit', 'LordOfTheRings', 'InvisibleMan'";
                john.DateOfIssue = DateTime.Parse("01.11.2020");
                TimeSpan ts1 = new TimeSpan(22, 0, 0, 0);
                john.AmountOfDays = ts1;
                john.ReturnDate = john.DateOfIssue.AddDays(ts1.Days);
                john.PiedgeAmount = 300;

                TextWriter oldOut = Console.Out;

                using (FileStream file = new FileStream("test.txt", FileMode.Create))
                {
                    using (TextWriter writer = new StreamWriter(file))
                    {
                        Console.SetOut(writer); 
                        
                        john.PrintInfo();
                    }
                }

                Console.SetOut(oldOut);

                using (FileStream file = new FileStream("test.txt", FileMode.Open))
                {
                    using (TextReader reader = new StreamReader(file))
                    {
                        var i = 0; while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());
                        Assert.AreEqual(lines.Length, i);
                    }
                }

                File.Delete("test.txt");
            }
            private RegularReader GetTestRegularReader()
            {
                var reader = new RegularReader("John", "Smith", 239646, "21.12.2020", "Baker Street 12", "+3122020");
                return reader;
            }
        }

        [TestClass]
        public class TemporaryReaderUnitTest
        {
            [TestMethod]
            public void ConstructorTRTestMethod()
            {
                var mary = GetTestTemporaryReader();
                Assert.AreEqual("30.12.2020", mary.ExpirationDate.ToShortDateString());
                Assert.AreEqual("History, Biology", mary.DepartmentNames);
            }

            [TestMethod]
            public void PrintInfoTRTestMethod()
            {
                var mary = GetTestTemporaryReader();
                var lines = new[]
                {
                    "Mary Long",
                    "Номер читательского билета: 245654. Список названий взятой литературы: 'TheGreatGatsby', '1984'. Дата выдачи: 05.11.2020. Срок выдачи: 7. Дата планируемого возвращения: 12.11.2020. Сумма залога: 200.",
                    "Дата окончания допуска в библиотеку: 30.12.2020. Названия отделов, в которые разрешен допуск: History, Biology."
                };

                mary.TakenLiterature = "'TheGreatGatsby', '1984'";
                mary.DateOfIssue = DateTime.Parse("05.11.2020");
                TimeSpan ts2 = new TimeSpan(7, 0, 0, 0);
                mary.AmountOfDays = ts2;
                mary.ReturnDate = mary.DateOfIssue.AddDays(ts2.Days);
                mary.PiedgeAmount = 200;

                TextWriter oldOut = Console.Out;

                using (FileStream file = new FileStream("test.txt", FileMode.Create))
                {
                    using (TextWriter writer = new StreamWriter(file))
                    {
                        Console.SetOut(writer); 
                        mary.PrintInfo();
                    }
                }

                Console.SetOut(oldOut);

                using (FileStream file = new FileStream("test.txt", FileMode.Open))
                {
                    using (TextReader reader = new StreamReader(file))
                    {
                        var i = 0; while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());
                        Assert.AreEqual(lines.Length, i);
                    }
                }

                File.Delete("test.txt");
            }
            private TemporaryReader GetTestTemporaryReader()
            {
                var reader = new TemporaryReader("Mary", "Long", 245654, "30.12.2020", "History, Biology");
                return reader;
            }
        }

        [TestClass]
        public class VisitorUnitTest
        {
            [TestMethod]
            public void ConstructorVTestMethod()
            {
                var bob = GetTestVisitor();
                Assert.AreEqual("12.12.2020 12:30:00", bob.ArrivalTime.ToString("G"));
                Assert.AreEqual("12.12.2020 16:30:00", bob.LeavingTime.ToString("G"));
                Assert.AreEqual("Читательский билет", bob.CertificateName);
                Assert.AreEqual(21245, bob.IDNumber);
            }

            [TestMethod]
            public void PrintInfoVTestMethod()
            {
                var bob = GetTestVisitor();
                var lines = new[]
                {
                    "Bob Green",
                    "Номер читательского билета: 213345. Список названий взятой литературы: 'Jane Eyre', 'Emma'. Дата выдачи: 05.12.2020. Срок выдачи: 7. Дата планируемого возвращения: 12.12.2020. Сумма залога: 250.",
                    "Время прихода: 12.12.2020 12:30:00. Время ухода: 12.12.2020 16:30:00. Название и номер удостоверения личности: Читательский билет №21245."
                };

                bob.TakenLiterature = "'Jane Eyre', 'Emma'";
                bob.DateOfIssue = DateTime.Parse("05.12.2020");
                TimeSpan ts2 = new TimeSpan(7, 0, 0, 0);
                bob.AmountOfDays = ts2;
                bob.ReturnDate = bob.DateOfIssue.AddDays(ts2.Days);
                bob.PiedgeAmount = 250;


                TextWriter oldOut = Console.Out;

                using (FileStream file = new FileStream("test.txt", FileMode.Create))
                {
                    using (TextWriter writer = new StreamWriter(file))
                    {
                        Console.SetOut(writer); bob.PrintInfo();
                    }
                }

                Console.SetOut(oldOut);

                using (FileStream file = new FileStream("test.txt", FileMode.Open))
                {
                    using (TextReader reader = new StreamReader(file))
                    {
                        var i = 0; while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());
                        Assert.AreEqual(lines.Length, i);
                    }
                }

                File.Delete("test.txt");
            }
            private Visitor GetTestVisitor()
            {
                var reader = new Visitor("Bob", "Green", 213345, "12.12.2020 12:30:00", "12.12.2020 16:30:00", "Читательский билет", 21245);
                return reader;
            }
        }
    }
}