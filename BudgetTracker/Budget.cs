using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    public class Budget
    {
        public double income { get; set; }
        public double expense { get; set; }
        public double balance { get; set; }
        public DateOnly dateOfBudgetHandeled { get; set; }

        public Budget(double income, double expense, DateOnly dateOfBudgetHandeled)
        {
            this.income = income;

            this.expense = expense;

            this.balance = income - expense;

            this.dateOfBudgetHandeled = dateOfBudgetHandeled;
        }
    }
    public class BudgetExecuter
    {
        public static bool IsFolderEmpty(string path)
        {
            return Directory.Exists(path) &&
                   Directory.GetFileSystemEntries(path).Length == 0;
        }

        public static Budget CalculateDailyBudget(DateOnly dateOfExpence, String incomeText, String expenseText)
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

        public static String? TakeInput(String input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        public static void ShowTodayBudget(Budget budget)
        {
            Console.WriteLine($"Your today income in the begining of the day {budget.income} LKR");
            Console.WriteLine($"Your today expenses are {budget.expense} LKR");
            Console.WriteLine($"Your today balance is {budget.balance} LKR");
        }
    }
    
}
