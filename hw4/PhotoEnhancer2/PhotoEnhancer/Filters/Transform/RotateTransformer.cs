using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class RotateTransformer : ITransformer<RotationParameters>
    {
        public Size ResultSize { get; private set; }

        Size size;
        double angleInRadians;

        public void Initialize(Size size, RotationParameters parameters)
        {
            this.size = size;
            angleInRadians = parameters.AngleInDegrees * Math.PI / 180;

            ResultSize = new Size(
                        (int)Math.Round((Math.Abs(Math.Cos(angleInRadians)) * size.Width +
                            Math.Abs(Math.Sin(angleInRadians)) * size.Height)),
                        (int)Math.Round(Math.Abs(Math.Sin(angleInRadians)) * size.Width +
                            Math.Abs(Math.Cos(angleInRadians)) * size.Height));
        }

        public Point? MapPoint(Point newPoint)
        {
            var p = new Point(newPoint.X - ResultSize.Width / 2,
                        newPoint.Y - ResultSize.Height / 2);

            var x = (int)Math.Round((p.X * Math.Cos(angleInRadians) -
                p.Y * Math.Sin(angleInRadians) + size.Width / 2));

            var y = (int)Math.Round((p.X * Math.Sin(angleInRadians) +
                p.Y * Math.Cos(angleInRadians) + size.Height / 2));

            if (x < 0 || x >= size.Width || y < 0 || y >= size.Height)
                return null;

            return new Point(x, y);
        }
    }
}
