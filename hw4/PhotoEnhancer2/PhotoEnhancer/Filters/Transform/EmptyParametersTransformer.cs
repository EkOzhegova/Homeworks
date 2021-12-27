using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class EmptyParametersTransformer : ITransformer<EmptyParameters>
    {
        public Size ResultSize { get; private set; }
        Func<Size, Size> sizeTransformer;
        Func<Point, Size, Point> pointTransformer;
        Size size;

        public EmptyParametersTransformer(Func<Size, Size> sizeTransformer, 
                Func<Point, Size, Point> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        public void Initialize(Size size, EmptyParameters parameters)
        {
            this.size = size;
            ResultSize = sizeTransformer(size);
        }

        public Point? MapPoint(Point newPoint)
        {
            return pointTransformer(newPoint, size);
        }
    }
}
