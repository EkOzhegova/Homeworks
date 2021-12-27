using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        Func<Size, Size> sizeTransform;

        //по точкет нового фото и размеру старого фото
        // определяется соотвествующая точка старого фото,
        // которая переходит в данную точку нового фото
        Func<Point, Size, Point> pointTransform;

        public TransformFilter(string name, Func<Size, Size> sizeTransform, 
            Func<Point, Size, Point> pointTransform) : base(name)
        {
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;          
        }

        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);

            for(var x = 0; x < newSize.Width; x++)
                for(var y = 0; y < newSize.Height; y++)
                {
                    var oldPoint = pointTransform(new Point(x, y), oldSize);
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
                }

            return result;
        }
    }
}
