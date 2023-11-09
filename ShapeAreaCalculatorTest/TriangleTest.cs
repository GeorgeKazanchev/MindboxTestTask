using ShapeAreaCalculator;

namespace ShapeAreaCalculatorTest
{
    [TestFixture]
    public class TriangleTest
    {
        #region Constructor tests

        [Test]
        public void ConstructorTest__ValidData()
        {
            double a = 1;
            double b = 1;
            double c = 1;

            Triangle triangle = new(a, b, c);

            Assert.Multiple(() =>
            {
                Assert.That(triangle.SideA, Is.EqualTo(a));
                Assert.That(triangle.SideB, Is.EqualTo(b));
                Assert.That(triangle.SideC, Is.EqualTo(c));
            });
        }

        [Test]
        public void ConstructorTest__A_Negative()
        {
            double a = -1;
            double b = 1;
            double c = 1;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__B_Negative()
        {
            double a = 1;
            double b = -1;
            double c = 1;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__C_Negative()
        {
            double a = 1;
            double b = 1;
            double c = -1;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__A_Zero()
        {
            double a = 0;
            double b = 1;
            double c = 1;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__B_Zero()
        {
            double a = 1;
            double b = 0;
            double c = 1;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__C_Zero()
        {
            double a = 1;
            double b = 1;
            double c = 0;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__A_Greater_B_Plus_C()
        {
            double b = 1;
            double c = 1;
            const double epsilon = 1e-12;
            double a = b + c + epsilon;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__B_Greater_A_Plus_C()
        {
            double a = 1;
            double c = 1;
            const double epsilon = 1e-12;
            double b = a + c + epsilon;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__C_Greater_A_Plus_B()
        {
            double a = 1;
            double b = 1;
            const double epsilon = 1e-12;
            double c = a + b + epsilon;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__TriangleSidesAreVeryLarge()
        {
            double a = double.MaxValue / 3;
            double b = double.MaxValue / 3;
            const double epsilon = 1e-12;
            double c = double.MaxValue / 3 + epsilon;

            bool isExceptionCaught = ConstructTriangleAndTryToCatchException(a, b, c);

            Assert.That(isExceptionCaught, Is.True);
        }

        #endregion

        #region Perimeter calculation tests

        [Test]
        public void PerimeterCalculation_ValidData()
        {
            double a = 10;
            double b = 10;
            double c = 20;
            Triangle triangle = new(a, b, c);
            
            double trianglePerimeter = triangle.Perimeter;

            Assert.That(trianglePerimeter, Is.EqualTo(a + b + c));
        }

        #endregion

        #region Area calculation tests

        [Test]
        public void AreaCalculationTest__ValidData()
        {
            double a = 10;
            double b = 15;
            double c = 20;
            Triangle triangle = new(a, b, c);
            
            double triangleArea = triangle.Area;

            const double tolerance = 1e-6;
            const double areaCalculatedViaInternet = 72.618437;
            Assert.That(triangleArea, Is.EqualTo(areaCalculatedViaInternet).Within(tolerance));
        }

        #endregion

        #region Triangle is right-angled checking tests

        [Test]
        public void TriangleIsRightTest__True()
        {
            double a = 10;
            double b = 10;
            double c = Math.Sqrt(a * a + b * b);
            Triangle triangle = new(a, b, c);

            bool isTriangleRight = triangle.IsRight;

            Assert.That(isTriangleRight, Is.True);
        }

        [Test]
        public void TriangleIsRightTest__False()
        {
            double a = 10;
            double b = 10;
            double c = a + b;
            Triangle triangle = new(a, b, c);

            bool isTriangleRight = triangle.IsRight;

            Assert.That(isTriangleRight, Is.False);
        }

        #endregion

        #region Private utility methods

        private static bool ConstructTriangleAndTryToCatchException(double sideA, double sideB, double sideC)
        {
            bool isExceptionCaught = false;
            try
            {
                Triangle _ = new(sideA, sideB, sideC);
            }
            catch (ArgumentException)
            {
                isExceptionCaught = true;
            }

            return isExceptionCaught;
        }

        #endregion
    }
}