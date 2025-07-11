# 💰 BudgetTracker 1.0
BudgetTracker 1.0 is a simple C# and .NET console application designed to help you track your daily expenses in an easy and organized manner. It allows you to log your daily budgets and expenses, which are stored as JSON files for simplicity and portability.

## 🧾 Features 
✅ Track daily expenses

📊 Compare today’s budget with yesterday’s

💾 Store and load budget data using JSON files

🧼 Clean and minimal console interface

📦 Simple architecture using namespaces and a program entry point

## 📁 Project Structure 
The project contains the following C# source files:

Program.cs – Entry point of the application

Budget.cs – Contains the Budget class, budget logic, and tracker functions

BudgetAnalyzer.cs – Handles comparing the budget between two days

All daily budget entries are saved in the DailyBudget/ folder inside the project directory, named by date (yyyyMMdd.json).

## 🛠️ Technologies Used ##
C#

.NET SDK

System.Text.Json for JSON serialization/deserialization

## 🚀 Getting Started 
Clone the repository:
bash
Copy
Edit
git clone https://github.com/Wish245/BudgetTracker1.0.git
cd BudgetTracker1.0
Build and run the application:
bash
Copy
Edit
dotnet build
dotnet run
Follow the console prompts to add or view your daily budgets.

## 📂 Data Storage
Budget entries are saved locally as .json files inside the DailyBudget/ folder within the project directory.

Filenames follow the format: yyyyMMdd.json (e.g., 20250711.json).

## 📌 Notes
🧪 Designed for simplicity and learning purposes

🔧 Can be extended to include:

.Monthly summaries

.Expense categories

.Graphical UI (GUI)

.🤖 Will introduce ML modules in future versions for smarter financial insights

## 📄 License
This project is open source. Feel free to use, modify, and distribute it.
