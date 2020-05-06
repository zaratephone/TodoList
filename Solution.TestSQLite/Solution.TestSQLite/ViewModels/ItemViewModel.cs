using Solution.TestSQLite.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace Solution.TestSQLite.ViewModels {
    public class ItemViewModel : BaseViewModel {

        public ItemSQLite Item { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public string Text { get; set; }
        public bool IsDelete { get; set; }

        public ItemViewModel(ItemSQLite item) {
            Item = item;
            if (string.IsNullOrEmpty(item.ID)) {
                Text = "Agregar";
            } else {
                Text = "Actualizar";
                IsDelete = true;
            }
            UpdateCommand = new Command(OnUpdate);
            DeleteCommand = new Command(OnDelete);
        }

        void OnLoad() {

        }

        async void OnUpdate() {
            await App.Database.SaveItemAsync(Item);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        async void OnDelete() {
            await App.Database.DeleteItemAsync(Item);
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
