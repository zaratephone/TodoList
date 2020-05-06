using Solution.TestSQLite.Models;
using Solution.TestSQLite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Solution.TestSQLite.ViewModels {

    public class ListViewModel : BaseViewModel {

        private int countItems;
        public int CountItems {
            get { return countItems; }
            set { countItems = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ItemSQLite> items = new ObservableCollection<ItemSQLite>();
        public ObservableCollection<ItemSQLite> Items {
            get { return items; }
            set { items = value; OnPropertyChanged(); }
        }

        //public ObservableCollection<ItemSQLite> Items { get; set; }
        public Command AddCommand { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ListViewModel() {
            AddCommand = new Command(OnAdd);
            LoadItemsCommand = new Command(async () => await OnLoad());
        }

        public async Task OnLoad() {
            try {
                IsBusy = true;
                Items = new ObservableCollection<ItemSQLite>(await App.Database.GetItemsAsync());
                CountItems = Items.Count;
            } catch (Exception) {
                throw;
            } finally {
                IsBusy = false;
            }
        }

        void OnAdd() {
            App.Current.MainPage.Navigation.PushAsync(new ItemView(new ItemSQLite()));
        }

    }

}
