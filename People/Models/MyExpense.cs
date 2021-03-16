using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expense_Analysis.Models
{
    [Table("Expense")]
   public  class MyExpense
    {
        [PrimaryKey , AutoIncrement]
        public int ExpenseID { get; set; }
        [ MaxLength(600)]
        public string ExpenseCategory { get; set; }
        [NotNull]
        public string ExpenseName { get; set; }
        [NotNull]
        public string  Date { get; set; }
        [NotNull]
        public decimal ExpensssAmount { get; set; }

    }
}
