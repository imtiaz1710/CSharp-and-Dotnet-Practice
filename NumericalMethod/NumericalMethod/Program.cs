using System;


Console.WriteLine("Enter number of data you want to input: ");
var n = int.Parse(Console.ReadLine());

var x = new float[n+10];
var y = new float[n+10];
float yp = 0;

Console.WriteLine("Enter your data:");

for (var i = 1; i <= n; i++)
{
    Console.Write($"x[{i}] = ");
	x[i] = float.Parse(Console.ReadLine());

	Console.Write($"y[{i}] = ");
	y[i] = float.Parse(Console.ReadLine());
}

Console.WriteLine("Enter interpolation point: ");
var xp = float.Parse(Console.ReadLine());

for (var i = 1; i <= n; i++)
{
	var p = 1f;
	for (var j = 1; j <= n; j++)
	{
		if (i != j)
		{
			p = p * (xp - x[j]) / (x[i] - x[j]);
		}
	}
	yp = yp + p * y[i];
}

Console.WriteLine($"Interpolated value at {xp} is {yp}.");
