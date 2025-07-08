using System;
using System.Text.Json;
using System.IO;

class Budget
{
    public double income { get; set;}
    public double expense { get; set;}
    public double balance { get; set; }
    public DateOnly trackDate { get; set;}

    public Budget(double income, double expense, DateOnly trackDate)
    {
        this.income = income;
       
        this.expense = expense;
        
        this.balance = income - expense;
        
        this.trackDate = trackDate;
    }
}

class BudgetTracker
{
    public static void Main(String[] args)
    {
        try
        {
            DateOnly extTime = DateOnly.FromDateTime(DateTime.Now);
            DateOnly yestTime = extTime.AddDays(-1);

            String formattedDateTime = extTime.ToString("yyyyMMddHHmmss");
            String formattedyestTime = yestTime.ToString("yyyyMMddHHmmss");
            String folderPath = "F:\\SankhaProjects\\BudgetTracker\\DailyBudget";
            String fileName = $"{formattedDateTime}.json";
            String fileYestName = $"{formattedyestTime}.json";
            bool fileExists = Directory.EnumerateFiles(folderPath, fileName, SearchOption.AllDirectories).Any();
            bool fileYestExists = Directory.EnumerateFiles(folderPath, fileName, SearchOption.AllDirectories).Any();
            if (!fileExists)
            {
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

                Budget budget = new Budget(inc, exp, extTime);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(budget);

                File.WriteAllText(filePath, jsonString);

                Console.WriteLine(jsonString);
            }
            else if(!IsFolderEmpty(folderPath) && !fileYestExists)
            {
                String filePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedyestTime}.json";

                Console.WriteLine("Welcome to the Daily Budget Tracker");

                Console.WriteLine($"Its {yestTime}");

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

                Budget budget = new Budget(inc, exp, yestTime);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(budget);

                File.WriteAllText(filePath, jsonString);

                Console.WriteLine(jsonString);
            }
            else
            {
                throw new Exception("File already existig, try again tomorrow");
            }
        
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static bool IsFolderEmpty(string path)
    {
        return Directory.Exists(path) &&
               Directory.GetFileSystemEntries(path).Length == 0;
    }
}