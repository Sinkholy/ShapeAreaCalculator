namespace ShapeAreaCalculation.Utility
{
	internal static class DoubleComparer
	{
		const double Precision = 0.001;

		internal static bool IsEqual(double a, double b)
		{
			return Math.Abs(a - b) < Precision;
		}
	}
}
