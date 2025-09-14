namespace expenseTracker
{
    internal class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public Expense(string name, decimal amount, DateTime date, string category)
        {
            Name = name;
            Amount = amount;
            Date = date;
            Category = category;
        }

        public static void AddExpense(List<Expense> expenses)
        {
            Expense expense = new Expense("", 0, DateTime.Now, "");

            Console.Write("Name: ");
            expense.Name = Console.ReadLine()!;
            Console.Write("Amount: ");
            expense.Amount = Convert.ToDecimal(Console.ReadLine()!);
            Console.Write("Category: ");
            expense.Category = Console.ReadLine()!;
            Console.Write("Date (mm/dd/yyyy): ");
            expense.Date = DateTime.Parse(Console.ReadLine()!);
            expenses.Add(expense);
        }

        public static void Print(List<Expense> expenses)
        {
            foreach (Expense expense in expenses)
                Console.WriteLine(expense);
        }

        public static void Filter(List<Expense> expenses, ref List<Expense> filtered)
        {
            Console.WriteLine("Filter by Category (Enter 'C')  |  Filter by Date (Enter 'D')");
            string choice = Console.ReadLine()!;
            switch (choice.ToLower())
            {
                case "c":
                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine()!;
                    filtered = expenses.Where(e => e.Category.ToLower() == category.ToLower()).ToList();
                    break;
                case "d":
                    Console.Write("From (mm/dd/yyyy): ");
                    var from = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("To (mm/dd/yyyy): ");
                    var to = DateTime.Parse(Console.ReadLine()!);

                    if (from > to)
                    {
                        Console.WriteLine("Invalid date range !");
                        break;
                    }

                    filtered = expenses.Where(e => e.Date >= from && e.Date <= to).OrderBy(d => d.Date).ToList();
                    break;
                default:
                    Console.WriteLine("Choose proper option !");
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name}:\t{Amount} ¥;\t{Category}; {Date:d};";
        }
    }
}
