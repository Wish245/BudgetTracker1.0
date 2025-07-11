using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker;

namespace BudgetAnalyzer
{
   public class BudgetComparission
    {
        public static void IncomeComparission(Budget budget, Budget yesterdayBudget)
        {
            Console.WriteLine($"The money you had initially in the begining of the day was {budget.income} LKR");
            if(budget.income > yesterdayBudget.balance)
            {
                Console.Write($"You had {yesterdayBudget.balance} LKR yesterday.");
                Console.WriteLine($"You have earned {yesterdayBudget.balance - budget.income} LKR within yesterday.");
                if(budget.balance > yesterdayBudget.balance)
                {
                    Console.WriteLine($"You spent only {budget.expense} LKR today.");
                    Console.WriteLine($"Which means you have saved {budget.balance - yesterdayBudget.balance} LKR.");
                    Console.WriteLine($"Which means you should save and deposit that extra {budget.balance - yesterdayBudget.balance} LKR");
                }
                if(budget.balance < yesterdayBudget.balance)
                {
                    Console.WriteLine($"You have saved {yesterdayBudget.balance - budget.balance} LKR which is lower than {yesterdayBudget.balance} LKR");
                }
                if(budget.balance == yesterdayBudget.balance)
                {
                    Console.WriteLine($"You saved the same amount as yesterday which is {yesterdayBudget.balance} ");
                }
            }
            else if(budget.income == yesterdayBudget.balance)
            {
                Console.Write($"You had {yesterdayBudget.balance} LKR yesterday.");
                Console.WriteLine($"You have moved yesterday income to your wallet within yesterday.");
                if (budget.balance > yesterdayBudget.balance)
                {
                    Console.WriteLine($"You spent only {budget.expense} LKR today.");
                    Console.WriteLine($"Which means you have saved {budget.balance - yesterdayBudget.balance} LKR.");
                    Console.WriteLine($"Which means you should save and deposit that extra {budget.balance - yesterdayBudget.balance} LKR");
                }
                if (budget.balance < yesterdayBudget.balance)
                {
                    Console.WriteLine($"You have saved {yesterdayBudget.balance - budget.balance} LKR which is lower than {yesterdayBudget.balance} LKR");
                }
                if (budget.balance == yesterdayBudget.balance)
                {
                    Console.WriteLine($"You saved the same amount as yesterday which is {yesterdayBudget.balance} ");
                }
            }
            else
            {
                Console.WriteLine($"You had {yesterdayBudget.balance} LKR yterday");
                Console.WriteLine($"You have saved by depositing in bank {yesterdayBudget.balance - budget.income} LKR");

                if (budget.balance > yesterdayBudget.balance)
                {
                    Console.WriteLine($"You spent only {budget.expense} LKR today.");
                    Console.WriteLine($"Which means you have saved {budget.balance - yesterdayBudget.balance} LKR.");
                    Console.WriteLine($"Which means you should save and deposit that extra {budget.balance - yesterdayBudget.balance} LKR");
                }
                if (budget.balance < yesterdayBudget.balance)
                {
                    Console.WriteLine($"You have saved {yesterdayBudget.balance - budget.balance} LKR which is lower than {yesterdayBudget.balance} LKR");
                }
                if (budget.balance == yesterdayBudget.balance)
                {
                    Console.WriteLine($"You saved the same amount as yesterday which is {yesterdayBudget.balance} ");
                }
            }
        }
    }
}