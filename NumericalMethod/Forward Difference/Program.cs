using System;

// C# Program to interpolate using
// newton forward interpolation

class GFG
{
	// calculating u mentioned in the formula
	static double u_cal(double u, int n)
	{
		double temp = u;
		for (int i = 1; i < n; i++)
			temp = temp * (u - i);
		return temp;
	}

	// calculating factorial of given number n
	static int fact(int n)
	{
		int f = 1;
		for (int i = 2; i <= n; i++)
			f *= i;
		return f;
	}

	// Driver code
	public static void Main()
	{
		// Number of values given
		Console.WriteLine("Enter number of data you want to input: ");
		var n = int.Parse(Console.ReadLine());

		var x = new float[n + 10];
		var y = new float[n + 10, n+10];

		Console.WriteLine("Enter your data:");

		for (var i = 1; i <= n; i++)
		{
			Console.Write($"x[{i}] = ");
			x[i] = float.Parse(Console.ReadLine());

			Console.Write($"y[{i}] = ");
			y[i, 0] = float.Parse(Console.ReadLine());
		}

		// Calculating the forward difference
		// table
		for (int i = 1; i < n; i++)
		{
			for (int j = 0; j < n - i; j++)
				y[j, i] = y[j + 1, i - 1] - y[j, i - 1];
		}

		// Value to interpolate at

		Console.WriteLine("Enter interpolation point: ");
		double value = float.Parse(Console.ReadLine()); ;

		double sum = y[0, 0];
		double u = (value - x[0]) / (x[1] - x[0]);
		for (int i = 1; i < n; i++)
		{
			sum = sum + (u_cal(u, i) * y[0, i]) /
									fact(i);
		}

		Console.WriteLine("Value at " + value + " is " + Math.Round(sum, 6));
	}
}
