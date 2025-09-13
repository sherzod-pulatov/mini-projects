class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                RunCalculator();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine("Press '0' (zero) to continue, any other key to exit: ");
            if (Console.ReadLine()?.ToLower() != "0")
            {
                break;
            }
        }
    }

    static void RunCalculator()
    {
        Console.WriteLine("Welcome to the Calculator!");
        Console.Write("First number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Operation (+, -, *, /): ");
        string operation = Console.ReadLine()!;
        double result = 0;
        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Error: Division by zero.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Error: Invalid operation.");
                return;
        }
        Console.WriteLine($"Result: {result}");
    }
}