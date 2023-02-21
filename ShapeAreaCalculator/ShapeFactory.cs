﻿using ShapeAreaCalculation.Shapes;

namespace ShapeAreaCalculation
{
	internal class ShapeFactory
	{
		internal IShape GetCircle(double radius)
		{
			return new Circle()
			{
				Radius = radius
			};
		}
		internal IShape GetTriangle(double sideA, double sideB, double sideC)
		{
			if (IsRightTriangle(out var cathetusA, out var cathetusB, out var hypotenuse))
			{
				return new RightTriangle(cathetusA, cathetusB, hypotenuse);
			}
			else
			{
				return new Triangle()
				{
					SideA = sideA,
					SideB = sideB,
					SideC = sideC
				};
			}

			bool IsRightTriangle(out double cathetusA, out double cathetusB, out double hypotenuse)
			{
				// Теорема Пифагора поможет нам понять является ли треугольник прямоугольным.
				var sides = new double[] { sideA, sideB, sideC };
				Array.Sort(sides);

				cathetusA = sides[0];
				cathetusB = sides[1];
				hypotenuse = sides[2];

				return Math.Pow(cathetusA, 2) == Math.Pow(cathetusB, 2) + Math.Pow(hypotenuse, 2);
			}
		}
	}
}
