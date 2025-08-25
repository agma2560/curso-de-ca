namespace _01_Interface01
{
    public class Rectangle : IShape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height) 
            => (_width, _height) = (width, height);

        public double CalculateArea()
        {
            return _width * _height;
        }
    }
}
