using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class TransformFilter : TransformFilter<EmptyParameters>
    {
        public TransformFilter(string name, Func<Size, Size> sizeTransformer,
            Func<Point, Size, Point> pointTransformer) : 
            base(name, new EmptyParametersTransformer(sizeTransformer, pointTransformer)) { }
    }
}
