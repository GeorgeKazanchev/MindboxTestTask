using ShapeAreaCalculator;

namespace ShapeAreaCalculatorTest
{
    [TestFixture]
    public class CircleTest
    {
        #region Constructor tests

        [Test]
        public void ConstructorTest__ValidData()
        {
            double radius = 10;

            Circle circle = new(radius);

            Assert.That(circle.Radius, Is.EqualTo(radius));
        }

        [Test]
        public void ConstructorTest__Radius_Negative()
        {
            double radius = -1;

            bool isExceptionCaught = ConstructCircleAndTryToCatchException(radius);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__Radius_Zero()
        {
            double radius = 0;

            bool isExceptionCaught = ConstructCircleAndTryToCatchException(radius);

            Assert.That(isExceptionCaught, Is.True);
        }

        [Test]
        public void ConstructorTest__CircleRadiusIsVeryLarge()
        {
            double radius = double.MaxValue;

            bool isExceptionCaught = ConstructCircleAndTryToCatchException(radius);

            Assert.That(isExceptionCaught, Is.True);
        }

        #endregion

        #region Area calculation tests

        [Test]
        public void AreaCalculationTest__ValidData()
        {
            double radius = 169;
            Circle circle = new(radius);
            
            double circleArea = circle.Area;

            Assert.That(circleArea, Is.EqualTo(Math.PI * radius * radius));
        }

        #endregion

        #region Private utility methods

        private static bool ConstructCircleAndTryToCatchException(double radius)
        {
            bool isExceptionCaught = false;
            try
            {
                Circle _ = new(radius);
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