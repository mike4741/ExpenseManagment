using Expense_Analysis.Models;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage
    {
        public static MyExpensesRepository ExpenseRepo;
        public AddExpense()
        {
            InitializeComponent();
            ExpenseRepo = new MyExpensesRepository();

        }
        public string Text { get; internal set; }
        private void OnAddExpenseClicked(object sender, EventArgs e)
        {
         
                statusMessage.Text = "";
  
           ExpenseRepo.AddMyExpense(CategoryPicker.SelectedItem.ToString(), ExpensesFor.Text, datePicker.Date.ToString(), decimal.Parse( ExpensesAmount.Text));
           
            statusMessage.Text = ExpenseRepo.StatusMessage;

        }

        private  async void ShowExpenseClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<MyExpense> rep = await ExpenseRepo.GetMyExpense();

            MYExpenseList.ItemsSource = rep;
        }

       
    }
}