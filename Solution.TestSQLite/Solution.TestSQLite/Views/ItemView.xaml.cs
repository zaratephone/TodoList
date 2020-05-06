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
    public partial class ItemView : ContentPage {

        ItemViewModel viewModel;

        public ItemView(ItemSQLite item) {
            InitializeComponent();
            BindingContext = viewModel = new ItemViewModel(item);
        }
    }
}