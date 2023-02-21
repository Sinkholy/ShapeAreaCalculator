namespace ShapeAreaCalculation.Shapes
{
	class Triangle : IShape
	{
		internal double SideA { get; init; }
		internal double SideB { get; init; }
		internal double SideC { get; init; }

		public virtual double GetArea()
		{
			// Формула Герона.
			var semiperimeter = (SideA + SideB + SideC) / 2;
			return Math.Sqrt(semiperimeter * (semiperimeter - SideA) * (semiperimeter - SideB) * (semiperimeter - SideC));
		}
	}
}
