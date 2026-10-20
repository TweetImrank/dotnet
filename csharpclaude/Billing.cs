namespace Billing;

public static class Calculator
{
    // Tax rate defaults to 8% unless the caller overrides it
    public static decimal CalculateTax(decimal subtotal, decimal taxRate = 0.08m)
    {
        return Math.Round(subtotal * taxRate, 2);
    }

    public static decimal CalculateTotal(decimal subtotal, decimal tax)
    {
        return subtotal + tax;
    }
}
