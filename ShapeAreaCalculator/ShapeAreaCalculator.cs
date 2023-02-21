namespace ShapeAreaCalculation
{
	public class ShapeAreaCalculator
	{
		readonly ShapeFactory shapeFactory;

		public ShapeAreaCalculator()
		{
			shapeFactory = new ShapeFactory();
		}

		public double GetCircleArea(double radius)
		{
			VerifyArgumentIsGreaterThanZero(radius, nameof(radius));

			var circle = shapeFactory.GetCircle(radius);
			return circle.GetArea();
		}
		public double GetTriangleArea(double sideA, double sideB, double sideC)
		{
			VerifyArgumentIsGreaterThanZero(sideA, nameof(sideA));
			VerifyArgumentIsGreaterThanZero(sideB, nameof(sideB));
			VerifyArgumentIsGreaterThanZero(sideC, nameof(sideC));
			VerifyTriangleCanExist();

			var triangle = shapeFactory.GetTriangle(sideA, sideB, sideC);
			return triangle.GetArea();

			void VerifyTriangleCanExist()
			{
				if(sideA + sideB < sideC || 
					sideA + sideC < sideB || 
					sideB + sideC < sideA)
				{
					throw new NonexistentTriangleException("A triangle with such parameters cannot exist.");
				}
			}
		}

		static void VerifyArgumentIsGreaterThanZero(double argument, string paramName)
		{
			if(argument <= 0.0)
			{
				throw new ArgumentOutOfRangeException(paramName, argument, "Argument cannot be zero or negative.");
			}
		}
	}

	public class NonexistentTriangleException : Exception
	{
		public NonexistentTriangleException(string? message) 
			: base(message) { }
	}
}