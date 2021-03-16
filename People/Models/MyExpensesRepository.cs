using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BudgetApp.Models;
using Expense_Analysis.Models;

namespace BudgetApp.Models
{
   public  class MyExpensesRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;
        string dbPath => FileAccessHelper.GetLocalFilePath("Budget2.db3");

        public MyExpensesRepository()
        {
            MyExpenssRepositoryConn(dbPath);
        }
        private void MyExpenssRepositoryConn(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<MyExpense>().Wait();
        }

        public async void AddMyExpense( string expenseCategory ,string expenseName,string date ,decimal amount)
        {
            int result = 0;
            try
            {

                if (string.IsNullOrEmpty(expenseCategory.ToString()))
                    throw new Exception("select expenseCategory");

                result = await conn.InsertAsync(
                    new MyExpense
                    {
                        ExpenseCategory = expenseCategory,
                        ExpenseName = expenseName,
                        Date = date,
                        ExpensssAmount = amount 
                     });
                ;

                StatusMessage = string.Format("{0} record(s) added [Data of : {1})", expenseCategory, amount);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", amount, ex.Message);
            }

        }

        internal async Task<List<MyExpense>> GetMyExpense()
        {
            try
            {
                return await conn.Table<MyExpense>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<MyExpense>();
        }
    }
}
