﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficent
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters> (
                "Оттенки серого",
                (pixel, parameters) => 
                    {
                        var channel = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
                        return new Pixel(channel, channel, channel);
                    }
                ));

            mainForm.AddFilter(new PixelFilter<GammaCorrectionParameters>(
              "Гамма-коррекция",
              (pixel, parameters) =>
              {
                  double H;
                  double S;
                  double L;
                  double Ln;

                  Pixel2HSL(pixel, out H, out S, out L);

                  Ln = Math.Pow(L, 1 / parameters.Coefficent);

                  return HSL2Pixel(H, S, Ln);
              }
              ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - 1 - point.X, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч. с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по вертикали",
                size => size,
                (point, size) => new Point(point.X, size.Height - 1 - point.Y)
                ));

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на заданный угол", new RotateTransformer()));

            mainForm.AddFilter(new TransformFilter<InclineParameters>(
                "Скос по горизонтали вниз", new InclineTransformer()));

            Application.Run(mainForm);
        }
        public static void Pixel2HSL(Pixel pixel, out double H, out double S, out double L)
        {
            double r = pixel.R / 255.0;
            double g = pixel.G / 255.0;
            double b = pixel.B / 255.0;
            double max, min, dif;
            double r2, g2, b2;

            H = 0;
            S = 0;
            L = 0;
            max = Math.Max(r, g);
            max = Math.Max(max, b);
            min = Math.Min(r, g);
            min = Math.Min(min, b);
            L = (min + max) / 2.0;

            if (L <= 0.0)
            {
                return;
            }

            dif = max - min;
            S = dif;

            if (S > 0.0)
            {
                S /= (L <= 0.5) ? (max + min) : (2.0 - max - min);
            }
            else
            {
                return;
            }

            r2 = (max - r) / dif;
            g2 = (max - g) / dif;
            b2 = (max - b) / dif;

            if (r == max)
            {
                H = (g == min ? 5.0 + b2 : 1.0 - g2);
            }
            else if (g == max)
            {
                H = (b == min ? 1.0 + r2 : 3.0 - b2);
            }
            else
            {
                H = (r == min ? 3.0 + g2 : 5.0 - r2);
            }

            H /= 6.0;
        }

        public static Pixel HSL2Pixel(double H, double S, double L)
        {
            double v;
            double r, g, b;
            double r1, g1, b1;

            r = L;
            g = L;
            b = L;

            v = (L <= 0.5) ? (L * (1.0 + S)) : (L + S - L * S);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = L + L - v;
                sv = (v - m) / v;
                H *= 6.0;
                sextant = (int)H;
                fract = H - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            r1 = Convert.ToByte(r * 255.0f);
            g1 = Convert.ToByte(g * 255.0f);
            b1 = Convert.ToByte(b * 255.0f);

            if (r1 > 1)
            {
                r1 = 1;
            }
            else if (r1 < 0)
            {
                r1 = 0;
            }

            if (g1 > 1)
            {
                g1 = 1;
            }
            else if (g1 < 0)
            {
                g1 = 0;
            }

            if (b1 > 1)
            {
                b1 = 1;
            }
            else if (b1 < 0)
            {
                b1 = 0;
            }

            Pixel pixel = new Pixel(0, 0, 0);

            pixel.R = r1;
            pixel.G = g1;
            pixel.B = b1;

            return pixel;
        }
    }
}