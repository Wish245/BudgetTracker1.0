using System;
using System.Text.Json;
using System.IO;

class Budget
{
    public double income { get; set;}
    public double expense { get; set;}
    public double balance { get; set; }
    public DateOnly dateOfBudgetHandeled { get; set;}

    public Budget(double income, double expense, DateOnly dateOfBudgetHandeled)
    {
        this.income = income;
       
        this.expense = expense;
        
        this.balance = income - expense;
        
        this.dateOfBudgetHandeled = dateOfBudgetHandeled;
    }
}

class BudgetTracker
{
    public static void Main(String[] args)
    {
        try
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            DateOnly yesterday = today.AddDays(-1);

            String formattedToday = today.ToString("yyyyMMdd");
            
            String formattedYesterday = yesterday.ToString("yyyyMMdd");
            
            String folderPath = "F:\\SankhaProjects\\BudgetTracker\\DailyBudget";
            
            String fileName = $"{formattedToday}.json";
            
            String fileYestName = $"{formattedYesterday}.json";
            
            bool fileExists = Directory.EnumerateFiles(folderPath, fileName, SearchOption.AllDirectories).Any();
            
            bool fileYestExists = Directory.EnumerateFiles(folderPath, fileName, SearchOption.AllDirectories).Any();
           
            if (!fileExists)
            {
                String filePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedToday}.json";

                WelcomeMessage(today);

                Budget budget = CalculateDailyBudget(today, incomeText, expenseText);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(budget, options);

                File.WriteAllText(filePath, jsonString);

                Console.WriteLine(jsonString);
            }
            else if(!IsFolderEmpty(folderPath) && !fileYestExists)
            {
                String filePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedYesterday}.json";

                Console.WriteLine("Welcome to the Daily Budget Tracker");

                Console.WriteLine($"Its {yesterday}");

                Console.WriteLine("To calculate the daily balance Please enter your income and expenses.");

                Console.WriteLine("**enter the money you had in the begining of the day as income**");

                Console.Write("Income: ");

                String incomeText = Console.ReadLine();

                Console.Write("Expenses: ");

                String expenseText = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(incomeText) || string.IsNullOrWhiteSpace(expenseText))
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

                Budget budget = CalculateDailyBudget(yesterday, incomeText, expenseText);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(budget);

                File.WriteAllText(filePath, jsonString);

                Console.WriteLine(jsonString, options);
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

    public static bool IsFolderEmpty(string path)
    {
        return Directory.Exists(path) &&
               Directory.GetFileSystemEntries(path).Length == 0;
    }

    public static Budget CalculateDailyBudget(DateOnly dateOfExpence,String incomeText, String expenseText)
    {
        if (!double.TryParse(incomeText, out double income))
            throw new Exception("Invalid input for income. Please enter a valid number.");

        if (!double.TryParse(expenseText, out double expense))
            throw new Exception("Invalid input for expense. Please enter a valid number.");

        Budget budget = new Budget(income, expense, dateOfExpence);
        return budget;
    }

    public static void WelcomeMessage(DateOnly today)
    {
        Console.WriteLine("Welcome to the Daily Budget Tracker");

        Console.WriteLine($"Its {today}");

        Console.WriteLine("To calculate the daily balance Please enter your income and expenses.");

        Console.WriteLine("**enter the money you had in the begining of the day as income**");
        
    }

    public static String TakeincomeText(String input)
    {
       
    }
}