namespace Scratchpad.Maths;

public static class Root
{
    public static double NthRoot(double num, double n, double initialGuess = 0)
    {
        // Start at quarter of the number to find nth root of. (Better than nothing)
        if (initialGuess == 0)
            initialGuess = num / 4;
        
        // Newton's Method
        double result = ((n-1)/n * initialGuess) + (num/n)*(1/Math.Pow(initialGuess, n-1));
    
        // Continue until accurate to 9 d.p.
        if (Math.Abs(result - initialGuess) < 0.000000001f)
            return result;
    
        Console.WriteLine(result);
        return NthRoot(num, n, result);        
    }
}