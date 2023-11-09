namespace ShapeAreaCalculator
{
    /// <summary>
    /// Interface of a shape whose area can be calculated.
    /// </summary>
    public interface IShapeAreaCalculated
    {
        /// <summary>
        /// Area of a shape, y.e.^2.
        /// </summary>
        public double Area { get; }
    }
}