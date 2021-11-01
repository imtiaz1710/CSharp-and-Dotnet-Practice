using System;

class GFG
{

	static int MAX_ITER = 1000000;

	//The function is x^3 - x^2 + 2
	static double func(double x)
	{
		return (x * x * x - x * x + 2);
	}

	// Prints root of func(x)
	// in interval [a, b]
	static void regulaFalsi(double a, double b)
	{
		if (func(a) * func(b) >= 0)
		{
			Console.WriteLine("You have not assumed right a and b");
		}
		// Initialize result
		double c = a;

		for (int i = 0; i < MAX_ITER; i++)
		{
			// Find the point that touches x axis
			c = (a * func(b) - b * func(a))
				/ (func(b) - func(a));

			// Check if the above found point is root
			if (func(c) == 0)
				break;

			// Decide the side to repeat the steps
			else if (func(c) * func(a) < 0)
				b = c;
			else
				a = c;
		}

		Console.WriteLine("The value of root is : " + (int)c);
	}

	// Driver program
	public static void Main(String[] args)
	{
		// Initial values assumed
		double a = -200, b = 300;
		regulaFalsi(a, b);
	}
}
