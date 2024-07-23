using System.Globalization;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    /// <summary>
    /// This is a delegate for calculating area
    /// </summary>
    /// <param name="r">Identifier dimension of the shape</param>
    /// <returns></returns>
    delegate double CalculateArea(int r);
    delegate double CalculateAreaMultiParameters(int l, int b);

    private static void Main(string[] args)
    {
        CalculateArea areapointer = CalculateCircleArea;

        Console.WriteLine("Hello, World!");

        #region Simple Delegation
        var area = areapointer(7);

        Console.WriteLine($"Area of a circle using Simple Delegation is {area}");

        #endregion

        #region Anonymous Method for area of a square with same delegate

        CalculateArea anpointer = new CalculateArea(delegate (int r)
        {
            return r * r;
        });

        var areaofasquare = anpointer(8);

        Console.WriteLine($"Area of a square using Anonymous method is {areaofasquare}");

        #endregion

        #region Lamda Expression

        CalculateAreaMultiParameters rectarea = (l, b) => l * b;

        Console.WriteLine($"Area of a rectangle using Lambda expression is {rectarea(4, 5)}");

        #endregion

        #region Lambda Expression + Function

        Func<int, int, double> trianglearea = (b, h) => 0.5 * b * h;

        Console.WriteLine($"Area of a triangle using lambda and function is {trianglearea(5, 6)}");

        #endregion

        #region Action

        Action<string> Greet = (s) => Console.WriteLine("Hello " + s);
        Greet("Ankur");

        #endregion

        #region Predicate

        Predicate<string> IsGreaterThan10 = (s) => s.Length > 10;
        string inputstring = "United States Of America";
        Console.WriteLine($"Is {inputstring} greater than 10? {IsGreaterThan10(inputstring)}");

        #endregion

    }

    static double CalculateCircleArea(int radius)
    {
        return 3.14 * radius * radius;
    }
}