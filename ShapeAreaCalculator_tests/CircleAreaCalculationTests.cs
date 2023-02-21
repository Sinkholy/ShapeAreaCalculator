using ShapeAreaCalculation;

namespace ShapeAreaCalculator_tests
{
	public class CircleAreaCalculationTests
	{
		[Fact]
		public void CircleWithWrongRadiusTest()
		{
			var calculator = new ShapeAreaCalculator();
			var exceptionThrowned = false;

			try
			{
				calculator.GetCircleArea(0.0);
			}
			catch(ArgumentOutOfRangeException)
			{
				exceptionThrowned = true;
			}
			Assert.True(exceptionThrowned);

			exceptionThrowned = false;
			try
			{
				calculator.GetCircleArea(-1.0);
			}
			catch(ArgumentOutOfRangeException)
			{
				exceptionThrowned = true;
			}
			Assert.True(exceptionThrowned);
		}

		[Fact]
		public void CirceAreaCalculationTest()
		{
			const string ErrorMessage = "Area mismatch.";

			var calculator = new ShapeAreaCalculator();
			SmallValuesTest();
			RegularValuesTest();
			LargeValuesTest();

			void SmallValuesTest()
			{
				var radius = 0.1;
				var areaExpected = 0.0314;
				var areaCalculated = Math.Round(calculator.GetCircleArea(radius), 4);

				Assert.True(areaExpected == areaCalculated, ErrorMessage);
			}
			void RegularValuesTest()
			{
				var radius = 13;
				var areaExpected = 530.929;
				var areaCalculated = Math.Round(calculator.GetCircleArea(radius), 3);

				Assert.True(areaExpected == areaCalculated, ErrorMessage);
			}
			void LargeValuesTest()
			{
				var radius = 666;
				var areaExpected = 1393472.271;
				var areaCalculated = Math.Round(calculator.GetCircleArea(radius), 3);

				Assert.True(areaExpected == areaCalculated, ErrorMessage);
			}
		}
	}
}
