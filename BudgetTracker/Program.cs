using System;
using System.Text.Json;

class Budget
{
    public double income { get; set;}
    public double expense { get; set;}
    public double balance { get; set; }
    public DateOnly trackDate { get; set;}

    public Budget(double income, double expense)
    {
        this.income = income;
        this.expense = expense;
        this.balance = income - expense;
        this.trackDate = DateOnly.FromDateTime(DateTime.Now);
    }
}

class BudgetTracker
{
    public static void Main(String[] args)
    {
        try
        {
            DateTime extTime = DateTime.Now;
            String formattedDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            String filePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedDateTime}.json";
            Console.WriteLine("Welcome to the Daily Budget Tracker");
            Console.WriteLine($"Its {extTime}");
            Console.WriteLine("To calculate the daily balance Please enter your income and expenses.");
            Console.WriteLine("**enter the money you had in the begining of the day as income**");
            Console.Write("Income: ");
            String inputIncome = Console.ReadLine();
            Console.Write("Expenses: ");
            String inputExpense = Console.ReadLine();
            double inc = Convert.ToDouble(inputIncome);
            Console.WriteLine(inc);
            double exp = Convert.ToDouble(inputExpense);
            Console.WriteLine(exp);
            Budget budget = new Budget(inc, exp);
            //var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(budget);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine(jsonString);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}