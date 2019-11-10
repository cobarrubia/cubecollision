
namespace DrawLibrary
{
    public sealed class Point
    {
        public double X { private set; get; }
        public double Y { private set; get; }
        public double Z { private set; get; }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
