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
    public partial class TestPage : ContentPage
    {
        public static MyBudgetRepository MyBudgetRepo;
     
        public TestPage()
        {
            InitializeComponent();
            MyBudgetRepo = new MyBudgetRepository();
        }

        public string Text { get; internal set; }

        private void OnAddBudgetClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            MyBudgetRepo.AddMyBudget(decimal.Parse (newAmount.Text), picker.SelectedItem.ToString());
            statusMessage.Text = MyBudgetRepo.StatusMessage;
        }

        private async void  OnGetBudgetClicked(object sender, EventArgs e)
        {
           statusMessage.Text = "";
            List<MyBudget> rep = await MyBudgetRepo.GetMyBudget();
            
            MYBUDGETLIST.ItemsSource = rep;
        }



       
    }
}