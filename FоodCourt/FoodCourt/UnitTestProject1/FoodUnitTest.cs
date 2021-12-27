using System;
using System.IO;
using FoodLibrary;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FoodUnitTests
{
    [TestClass]
    public class FoodUnitTest
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var milk = CreateTestFood();

            Assert.AreEqual(500, milk.Weight);
            Assert.AreEqual(45.1 * Math.Pow(10, -13), milk.Calorie * Math.Pow(10, -13));
            Assert.AreEqual(225.5 * Math.Pow(10, -13), milk.Value * Math.Pow(10, -13));
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var milk = CreateTestFood();
            Assert.AreEqual("500 г калорийности на 45,1 Ккал/100 г", milk.ToString());
        }

        [TestMethod]
        public void DisplayTestMethod()
        {
            var milk = CreateTestFood();
            var bread = new Food(100, 225.5);

            var consoleOut = new[]
            {
                "Структура 'Food', 500 г калорийности на 45,1 Ккал/100 г",
                "Структура 'Food', 100 г калорийности на 225,5 Ккал/100 г"
            };

            TextWriter oldOut = Console.Out;

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            milk.Display();
            bread.Display();

            Console.SetOut(oldOut);

            var outputArray = output.ToString().Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(2, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        [TestMethod]
        public void EqualsTestMethod()
        {
            Food f1 = new Food(1000, 155.2);

            Food f2 = new Food(1000, 155.2);

            Assert.AreEqual(true, f1.Equals(f2));
        }

        [TestMethod]
        public void PlusTestMethod()
        {
            Food f1 = new Food(1000, 124.9);

            Food f2 = new Food(500, 124.9);

            var f3 = f1 + f2;

            Assert.AreEqual("1500 г калорийности на 124,9 Ккал/100 г", f3.ToString());
        }

        [TestMethod]
        public void MinusTestMethod()
        {
            Food f1 = new Food(1000, 124.9);

            Food f2 = new Food(500, 124.9);

            var f3 = f1 - f2;

            Assert.AreEqual("500 г калорийности на 124,9 Ккал/100 г", f3.ToString());
        }
        private Food CreateTestFood()
        {
            return new Food(500, 45.1);
        }
    }
}
