namespace ShapeAreaCalculation.Shapes
{
	internal class RightTriangle : Triangle
	{
		internal RightTriangle(double cathetusA, double cathetusB, double hypotenuse)
		{
			// Этот конструктор нужен здесь для более явного обозначения сторон прямоугольного треугольника.
			SideA = cathetusA;
			SideB = cathetusB;
			SideC = hypotenuse;
		}

		public override double GetArea()
		{
			return (SideA * SideB) / 2;
		}
	}
}
