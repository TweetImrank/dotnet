// Bring in the Billing namespace
using Billing;

// Set up the order
string item = "Wireless Headphones";
int quantity = 2;
decimal unitPrice = 49.99m;
decimal subtotal = quantity * unitPrice;

// Calculate tax and total
decimal standardTax = Calculator.CalculateTax(subtotal);
decimal reducedTax = Calculator.CalculateTax(subtotal, taxRate: 0.05m);
decimal total = Calculator.CalculateTotal(subtotal, standardTax);
decimal reducedTotal = Calculator.CalculateTotal(subtotal, reducedTax);

// Print the receipt
Console.WriteLine("===== STORE RECEIPT =====");
Console.WriteLine($"{item} x{quantity} @ {unitPrice:C}");
Console.WriteLine($"Subtotal:            {subtotal:C}");
Console.WriteLine($"Tax (8% default):    {standardTax:C}");
Console.WriteLine($"Total:               {total:C}");
Console.WriteLine("-------------------------");
Console.WriteLine($"Tax (5% override):   {reducedTax:C}");
Console.WriteLine($"Total (reduced):     {reducedTotal:C}");
Console.WriteLine("=========================");
