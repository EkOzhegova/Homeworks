using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class InclineTransformer : ITransformer<InclineParameters>
    {
        public Size ResultSize { get; private set; }

        Size size;
        double angleInRadians;

        public void Initialize(Size size, InclineParameters parameters)
        {
            this.size = size;
            angleInRadians = parameters.AngleInDegrees * Math.PI / 180;

            ResultSize = new Size(
                         (int)Math.Round((Math.Abs(Math.Tan(angleInRadians) * size.Height) + size.Width)),
                         (int)size.Height);
        }

        public Point? MapPoint(Point newPoint)
        {
            var p = new Point(newPoint.X - ResultSize.Width / 2,
                        newPoint.Y - ResultSize.Height / 2);

            var x = (int)Math.Round((p.X -
              p.Y * Math.Tan(angleInRadians) + (size.Width / 2)));

            var y = (int)((p.Y) + size.Height / 2);

            if (x < 0 || x >= size.Width || y < 0 || y >= size.Height)
                return null;

            return new Point(x, y);
        }
    }
}
