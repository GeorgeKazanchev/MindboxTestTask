namespace ShapeAreaCalculator
{
    /// <summary>
    /// Class of a circle.
    /// </summary>
    public class Circle : IShapeAreaCalculated
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="radius"> Radius of a circle, y.e. </param>
        public Circle(double radius)
        {
            ValidateArguments(radius);
            Radius = radius;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Radius of a circle, y.e.
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Area of a circle, y.e.^2.
        /// </summary>
        public double Area => Math.PI * Radius * Radius;

        #endregion

        #region Private methods

        private void ValidateArguments(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The radius of the circle is less than or equal to 0.");
            }

            if (Math.PI * radius * radius > double.MaxValue)
            {
                throw new ArgumentException("The radius of the circle is unacceptable large.");
            }
        }

        #endregion
    }
}