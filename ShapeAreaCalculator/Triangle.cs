namespace ShapeAreaCalculator
{
    /// <summary>
    /// Class of a triangle.
    /// </summary>
    public class Triangle : IShapeAreaCalculated
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sideA"> Side A of a triangle, y.e. </param>
        /// <param name="sideB"> Side B of a triangle, y.e. </param>
        /// <param name="sideC"> Side C of a triangle, y.e. </param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            ValidateArguments(sideA, sideB, sideC);
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Side A of a triangle, y.e.
        /// </summary>
        public double SideA { get; private set; }

        /// <summary>
        /// Side B of a triangle, y.e.
        /// </summary>
        public double SideB { get; private set; }

        /// <summary>
        /// Side C of a triangle, y.e.
        /// </summary>
        public double SideC { get; private set; }

        /// <summary>
        /// Perimeter of a triangle, y.e.
        /// </summary>
        public double Perimeter => GetPerimeter(SideA, SideB, SideC);

        /// <summary>
        /// Area of a triangle, y.e.^2.
        /// </summary>
        public double Area => GetArea(SideA, SideB, SideC);

        /// <summary>
        /// Cosinus of an angle between the sides B and C of a triangle.
        /// </summary>
        public double CosAlpha => (SideB * SideB + SideC * SideC - SideA * SideA) / (2 * SideB * SideC);

        /// <summary>
        /// Cosinus of an angle between the sides A and C of a triangle.
        /// </summary>
        public double CosBeta => (SideA * SideA + SideC * SideC - SideB * SideB) / (2 * SideA * SideC);

        /// <summary>
        /// Cosinus of an angle between the sides A and B of a triangle.
        /// </summary>
        public double CosGamma => (SideA * SideA + SideB * SideB - SideC * SideC) / (2 * SideA * SideB);

        /// <summary>
        /// Sign means a triangle is a right-angled.
        /// </summary>
        public bool IsRight
        {
            get
            {
                if (CheckAngleIsRightByCos(CosAlpha)) return true;
                if (CheckAngleIsRightByCos(CosBeta)) return true;
                if (CheckAngleIsRightByCos(CosGamma)) return true;
                else return false;
            }
        }

        #endregion

        #region Private methods

        private void ValidateArguments(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("One or more sides of the triangle is less than or equal to 0.");
            }

            if ((sideA > sideB + sideC) || (sideB > sideA + sideC) || (sideC > sideA + sideB))
            {
                throw new ArgumentException("Triangle inequality is violated.");
            }

            if (GetArea(sideA, sideB, sideC) > double.MaxValue)
            {
                throw new ArgumentException("The triangle sides are unacceptable large.");
            }
        }

        private bool CheckAngleIsRightByCos(double cos)
        {
            const double tolerance = 1e-12;
            return Math.Abs(cos) < tolerance;
        }

        private double GetPerimeter(double sideA, double sideB, double sideC)
        {
            return sideA + sideB + sideC;
        }

        private double GetArea(double sideA, double sideB, double sideC)
        {
            double p = GetPerimeter(sideA, sideB, sideC) / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        #endregion
    }
}