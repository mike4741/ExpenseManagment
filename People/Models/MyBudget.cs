using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expense_Analysis.Models
{
    public enum ListOfMonth
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    [Table ("Budget")]
   public  class MyBudget
    {
        [PrimaryKey , AutoIncrement]
        public int BudgetID { get; set; }
        [Unique]
        public decimal  Amount { get; set; }
        [Unique ]
        public string Month { get; set; }
    }
}
