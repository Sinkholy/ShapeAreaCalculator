namespace ShapeAreaCalculation.Shapes
{
	class Circle : IShape
	{
		internal double Radius { get; init; }

		public double GetArea()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}
	}
}
