namespace _01_Interface01
{
    public class Triangle : IShape
    {
        private double _base;
        private double _height;

        public Triangle(double triangleBase, double height) 
            => (_base, _height) = (triangleBase, height);

        public double CalculateArea()
        {
            return (_base * _height) / 2;
        }
    }
}
