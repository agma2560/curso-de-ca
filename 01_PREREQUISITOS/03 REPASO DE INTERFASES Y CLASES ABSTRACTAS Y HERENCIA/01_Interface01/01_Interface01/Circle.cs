namespace _01_Interface01
{
    internal class Circle : IShape
    {
        private double _radius;

        public Circle(double radious) => _radius = radious;
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}
