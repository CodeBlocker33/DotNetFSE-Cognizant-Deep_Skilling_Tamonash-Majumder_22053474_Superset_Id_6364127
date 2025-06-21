using System;

class FinancialForecast
{
    public static double CalculateFutureValueRecursive(double presentValue, double growthRate, int years)
    {
        if (years == 0)
            return presentValue;

        return CalculateFutureValueRecursive(presentValue * (1 + growthRate), growthRate, years - 1);
    }
    public static double CalculateFutureValueIterative(double presentValue, double growthRate, int years)
    {
        for (int i = 0; i < years; i++)
        {
            presentValue *= (1 + growthRate);
        }
        return presentValue;
    }

    static void Main()
    {
        double presentValue = 1000;  
        double growthRate = 0.05;    
        int years = 6;               

        double futureRecursive = CalculateFutureValueRecursive(presentValue, growthRate, years);
        Console.WriteLine($"[Recursive] Future value after {years} years: {futureRecursive:C2}");

        double futureIterative = CalculateFutureValueIterative(presentValue, growthRate, years);
        Console.WriteLine($"[Iterative] Future value after {years} years: {futureIterative:C2}");
    }
}
