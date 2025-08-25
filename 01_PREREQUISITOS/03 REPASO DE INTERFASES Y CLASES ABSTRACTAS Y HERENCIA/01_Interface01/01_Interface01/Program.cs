using _01_Interface01;

namespace GeometryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>
            {
                new Triangle(10, 5),
                new Circle(7),
                new Rectangle(8, 6)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Área de la figura: {shape.GetType().Name} {shape.CalculateArea():F2}");
            }
        }
    }
}
