using ShapeAreaCalculation;

namespace ShapeAreaCalculator_tests
{
	public class TriangleAreaCalculationTests
	{
		[Fact]
		public void TriangleWithWrongSideTest()
		{
			var calculator = new ShapeAreaCalculator();
			var exceptionThrowned = false;

			try
			{
				calculator.GetTriangleArea(-1, 1, 1);
			}
			catch(ArgumentOutOfRangeException)
			{
				exceptionThrowned = true;
			}
			Assert.True(exceptionThrowned, "Triangle with negative SideA was provided, no exception was throwned.");

			exceptionThrowned = false;
			try
			{
				calculator.GetTriangleArea(1, -1, 1);
			}
			catch (ArgumentOutOfRangeException)
			{
				exceptionThrowned = true;
			}
			Assert.True(exceptionThrowned, "Triangle with negative SideB was provided, no exception was throwned.");

			exceptionThrowned = false;
			try
			{
				calculator.GetTriangleArea(1, 1, -1);
			}
			catch (ArgumentOutOfRangeException)
			{
				exceptionThrowned = true;
			}
			Assert.True(exceptionThrowned, "Triangle with negative SideC was provided, no exception was throwned.");

			exceptionThrowned = false;
			try
			{
				calculator.GetTriangleArea(1, 0, 1);
			}
			catch (ArgumentOutOfRangeException)
			{
				exceptionThrowned = true;
			}
			Assert.True(exceptionThrowned, "Triangle with zero SideB was provided, no exception was throwned.");
		}

		[Fact]
		public void NonexistentTriangleTest()
		{
			var calculator = new ShapeAreaCalculator();
			var exceptionThrowned = false;

			try
			{
				calculator.GetTriangleArea(12.0, 3.0, 4.0);
			}
			catch(NonexistentTriangleException)
			{
				exceptionThrowned = true;
			}

			Assert.True(exceptionThrowned);
		}

		[Fact]
		public void RegularTriangleAreaCalculationTest()
		{
			const string ErrorMessage = "Area mismatch.";

			var calculator = new ShapeAreaCalculator();
			SmallValuesTest();
			RegularValuesTest();
			LargeValuesTest();

			void SmallValuesTest()
			{
				var sideA = 2;
				var sideB = 3;
				var sideC = 4;
				var areaExpected = 2.905;
				var areaCalculated = Math.Round(calculator.GetTriangleArea(sideA, sideB, sideC), 3);

				Assert.True(areaExpected == areaCalculated, ErrorMessage);
			}
			void RegularValuesTest()
			{
				var sideA = 15;
				var sideB = 25;
				var sideC = 30;
				var areaExpected = 187.083;
				var areaCalculated = Math.Round(calculator.GetTriangleArea(sideA, sideB, sideC), 3);

				Assert.True(areaExpected == areaCalculated, ErrorMessage);
			}
			void LargeValuesTest()
			{
				var sideA = 250;
				var sideB = 194;
				var sideC = 100;
				var areaExpected = 8959.986;
				var areaCalculated = Math.Round(calculator.GetTriangleArea(sideA, sideB, sideC), 3);

				Assert.True(areaExpected == areaCalculated, ErrorMessage);
			}
		}

		[Fact]
		public void RightTriangleAreaCalculationTest()
		{
			var cathetusA = 0.4;
			var cathetusB = 0.3;
			var hypotenuse = 0.5;
			var areaExpected = 0.06;

			var calculator = new ShapeAreaCalculator();
			var areaCalculated = Math.Round(calculator.GetTriangleArea(cathetusA, cathetusB, hypotenuse), 2);

			Assert.True(areaExpected == areaCalculated);
		}
	}
}