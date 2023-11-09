using ShapeAreaCalculator;

namespace ShapeAreaCalculatorClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double radius = 10;
            IShapeAreaCalculated circle = new Circle(radius);
            double circleArea = circle.Area;
            Console.WriteLine($"Circle: radius = {radius}, area = {circleArea}.");

            double sideA = 10;
            double sideB = 20;
            double sideC = 15;
            IShapeAreaCalculated triangle = new Triangle(sideA, sideB, sideC);
            double triangleArea = triangle.Area;
            Console.WriteLine($"Triangle: sideA = {sideA}, sideB = {sideB}, sideC = {sideC}, area = {triangleArea}.");
        }
    }
}