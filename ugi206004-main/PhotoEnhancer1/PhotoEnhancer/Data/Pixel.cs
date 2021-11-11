using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    //пиксел имеет 3 канала, яркости которых - число от 0 до 1
    public struct Pixel
    {
        //интенсивность каждого канала - число с плавающей точкой от 0 до 1

        double r;
        public double R
        {
            get { return r; }

            set { r = CheckValue(value); }
        }

        double g;
        public double G
        {
            get { return g; }

            set { g = CheckValue(value); }
        }

        double b;
        public double B
        {
            get { return b; }

            set { b = CheckValue(value); }
        }

        public Pixel (double red, double green, double blue) : this()
        {
            R = red;
            G = green;
            B = blue;
        }

        public static Pixel operator *(Pixel p, double k)
        {
            return new Pixel(
                Trim(p.R * k), 
                Trim(p.G * k), 
                Trim(p.B * k)
                );
        }

        public static Pixel operator *(double k, Pixel p)
        {
            return p * k;
        }

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new ArgumentException($"Неверное значение {val}. Нужно от 0 до 1");

            return val;
        }

        public static double Trim(double channel)
        {
            if (channel > 1)
                return 1;

            if (channel < 0)
                return 0;

            return channel;
        }
    }
}
