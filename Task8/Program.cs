using System.Reflection;

Type myMatch = typeof(MyMatch);

MyMatch? match = (MyMatch?)(myMatch.GetConstructors()?.FirstOrDefault()?.Invoke(parameters: null));

var res = match?.Sum(1, 2);
Console.WriteLine(res);

public class MyMatch
{
	public int Sum(int a, int b)
	{
		return a + b;
	}

	public int Sum(int a, int b, int c)
	{
		return a + b + c;
	}

	public int Sum(int a, int b, int c, int d)
	{
		return a + b + c + d;
	}
}