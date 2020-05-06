using Solution.TestSQLite.Models;
using Solution.TestSQLite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Solution.TestSQLite.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView : ContentPage {

        ListViewModel viewModel;

        public ListView() {
            InitializeComponent();
            BindingContext = viewModel = new ListViewModel();
        }

        protected override async void OnAppearing() {
            base.OnAppearing();
            //if (viewModel.Items.Count == 0)
            //    viewModel.IsBusy = true;
            await viewModel.OnLoad();
            
        }

        async void OnItemSelected(object sender, EventArgs args) {
            var layout = (BindableObject)sender;
            var item = (ItemSQLite)layout.BindingContext;
            await Navigation.PushAsync(new ItemView(item));
        }

    }
}