using Expense_Analysis.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BudgetApp.Models;



namespace BudgetApp.Models
{
    public class MyBudgetRepository 
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;
        string dbPath => FileAccessHelper.GetLocalFilePath("Budget2.db3");

        public MyBudgetRepository()
        {
            MyBudgetRepositoryConn(dbPath);
        }

        private void MyBudgetRepositoryConn(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<MyBudget>().Wait();

        }
        public async void AddMyBudget(decimal amount, string month)
        {
            int result = 0;
            try
            {

                if (string.IsNullOrEmpty(month.ToString()))
                    throw new Exception("select the month");

                result = await conn.InsertAsync(
                    new MyBudget
                    {
                        Amount = amount,
                        Month = month
                    });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, amount);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", amount, ex.Message);
            }

        }

        internal  async Task<List<MyBudget>> GetMyBudget()
        {
            try
            {
                return await conn.Table<MyBudget>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<MyBudget>();
        }

       /* public async  Task<List<MyBudget>> GetMyBudget(string month)
        {
            try
            {
                var budget = from u in conn.Table<MyBudget>()
                             where u.Month == month
                             select u;

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }


            return  new List<MyBudget>();
        }


        */

    }
}
