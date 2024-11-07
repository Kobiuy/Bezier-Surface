namespace Bezier_Surface
{
	public static class MathHelper
	{
		public static float Factorial(int n)
		{
			float result = 1;
			for (int i = 2; i <= n; ++i)
			{
				result *= i;
			}
			return result;
		}

		public static float NewtonBinomial(int n, int k)
		{
			if (k > n) return 0;
			return Factorial(n) / (Factorial(k) * Factorial(n - k));
		}
		public static float CalcB(int i, int n, float t)
		{
			return NewtonBinomial(n, i) * MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
		}
	}
}
