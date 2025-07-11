using System;
using System.Text.Json;
using System.IO;
using BudgetTracker;
using BudgetAnalyzer;
using System.Threading.Tasks;


class BudgetViewer
{
    public static async Task Main(String[] args)
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

                String yesterdayFilePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedYesterday}.json";

                BudgetExecuter.WelcomeMessage(today);

                String? incomeText = BudgetTracker.BudgetExecuter.TakeInput("Income: ");

                String? expenseText = BudgetTracker.BudgetExecuter.TakeInput("Expense: ");

                if (string.IsNullOrWhiteSpace(incomeText) || !double.TryParse(incomeText, out double income))
                {
                    Console.WriteLine("Invalid income input.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(expenseText) || !double.TryParse(expenseText, out double expense))
                {
                    Console.WriteLine("Invalid income input.");
                    return;
                }

                Budget budget = BudgetTracker.BudgetExecuter.CalculateDailyBudget(today, incomeText, expenseText);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(budget, options);

                File.WriteAllText(filePath, jsonString);
                BudgetTracker.BudgetExecuter.ShowTodayBudget(budget);

                Console.WriteLine("Within a minuite you will be seeing the analysis compared to yesterdaay");
                await Task.Delay(10000);

                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("*******Today Analysis*********");
                try
                {
                    String jsonNewString = File.ReadAllText(yesterdayFilePath);
                    Budget? yesterdayBudget = JsonSerializer.Deserialize<Budget>(jsonNewString);
                    BudgetAnalyzer.BudgetComparission.IncomeComparission(budget, yesterdayBudget);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Error: File not found at {filePath}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                await Task.Delay(10000);
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("press any key to close");
                await Task.Delay(10000);
                Console.ReadKey();
            }
            else if(!BudgetTracker.BudgetExecuter.IsFolderEmpty(folderPath) && !fileYestExists)
            {
                String filePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedYesterday}.json";
                DateOnly dayBeforeYesterday = today.AddDays(-1);
                String formattedDayBeforeYesterday = dayBeforeYesterday.ToString("yyyyMMdd");
                String dayBeforeYesterdayFilePath = $"F:\\SankhaProjects\\BudgetTracker\\DailyBudget\\{formattedDayBeforeYesterday}.json";

                BudgetTracker.BudgetExecuter.WelcomeMessage(yesterday);

                String? incomeText = BudgetTracker.BudgetExecuter.TakeInput("Income: ");

                String? expenseText = BudgetTracker.BudgetExecuter.TakeInput("Expense: ");

                if (string.IsNullOrWhiteSpace(incomeText) || !double.TryParse(incomeText, out double income))
                {
                    Console.WriteLine("Invalid income input.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(expenseText) || !double.TryParse(expenseText, out double expense))
                {
                    Console.WriteLine("Invalid income input.");
                    return;
                }

                Budget budget = BudgetTracker.BudgetExecuter.CalculateDailyBudget(yesterday, incomeText, expenseText);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(budget);

                File.WriteAllText(filePath, jsonString);
                BudgetTracker.BudgetExecuter.ShowTodayBudget(budget);

                Console.WriteLine("Within a minuite you will be seeing the analysis compared to yesterdaay");
                await Task.Delay(10000);

                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("*******Today Analysis*********");
                try
                {
                    String jsonNewString = File.ReadAllText(dayBeforeYesterdayFilePath);
                    Budget? yesterdayBudget = JsonSerializer.Deserialize<Budget>(jsonNewString);
                    BudgetAnalyzer.BudgetComparission.IncomeComparission(budget, yesterdayBudget);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Error: File not found at {filePath}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                await Task.Delay(10000);
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("press any key to close");
                await Task.Delay(10000);
                Console.ReadKey();

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
  
}