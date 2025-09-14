namespace expenseTracker;

using System;
using System.Linq;
using System.Collections.Generic;
using static expenseTracker.Expense;

class Program
{
    static void Main(string[] args)
    {
        List<Expense> expenses = new List<Expense>()
        {
            new Expense("Groceries", 42, DateTime.Parse("09/07/2025"), "Food"),
            new Expense("Lunch at uni", 3.44m, DateTime.Today, "Food"),
            new Expense("Train Ticket", 15.5m, DateTime.Parse("08/01/2025"), "Commute")
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\t\t\tMY EXPENSE TRACKER\n");
            Console.Write("A. Add New\tF. Filter By\tT. Total Spent\tQ. Quit\n\n");
            Print(expenses);

            string choice = Console.ReadLine()!;
            Console.WriteLine();
            switch (choice.ToLower())
            {
                case "a":
                    AddExpense(expenses);
                    break;
                case "f":
                    var filtered = new List<Expense>();
                    Filter(expenses, ref filtered);
                    Print(filtered);
                    break;
                case "t":
                    Console.WriteLine($"Total money spent: {expenses.Sum(e => e.Amount)} ¥");
                    break;
                case "q":
                    return;
                default:
                    Console.WriteLine("Choose proper option !");
                    break;
            }
            Console.ReadKey();
        }
    }
}