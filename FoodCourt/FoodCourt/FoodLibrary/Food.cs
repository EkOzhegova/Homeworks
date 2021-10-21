using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLibrary
{
    public struct Food
    {
        public int Weight;
        public double Calorie;
        public readonly double Value;

        public Food(int weight, double calorie)
        {
           if (weight < 0 || calorie < 0)
           {
               throw new Exception("Передаваемые значения должны быть больше нуля!");
           }

           Weight = weight;
           Calorie = calorie;
           Value = (Weight / 100) * Calorie;
        }

        public static Food Read()
        {
            int w;
            double c;

            while (true)
            {
                Console.WriteLine("Введите вес продукта:");
                 w = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите калорийность в 100 гр. продукта:");
                c = double.Parse(Console.ReadLine());

                if (c < 0 || w < 0)
                {
                    Console.WriteLine("Передаваемые значения должны быть больше нуля!");
                }
                else
                {
                    break;
                }
            }

            return new Food(w, c);
        }

        public override string ToString()
        {
            return $"{Weight.ToString()} г калорийности на {Calorie.ToString()} Ккал/100 г";
        }

        public override bool Equals(object obj)
        {
            if (obj is Food)
            {
                Food f = (Food)obj;

                return Weight == f.Weight && Calorie * Math.Pow(10, -13) == f.Calorie * Math.Pow(10, -13);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Weight.GetHashCode() ^ Calorie.GetHashCode();
        }

        public void Display()
        {
            Console.WriteLine($"Структура 'Food', {Weight.ToString()} г калорийности на {Calorie.ToString()} Ккал/100 г");
        }

        public static Food operator +(Food f1, Food f2)
        {
            if (f1.Calorie == f2.Calorie)
            {
                return new Food(f1.Weight + f2.Weight, f1.Calorie);
            }
            else
            {
                throw new Exception("Сложение веса невозможно, так как количество калорий на 100 гр. не совпадает!");
            }
        }

        public static Food operator -(Food f1, Food f2)
        {
            if (f1.Calorie == f2.Calorie && f1.Weight >= f2.Weight)
            {
                return new Food(f1.Weight - f2.Weight, f1.Calorie);
            }
            else
            {
                throw new Exception("Вычитание пачек невозможно, так как не совпадает номинал или в первой пачке меньше банкнот!");
            }
        }

    }
}
