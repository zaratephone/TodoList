using Solution.TestSQLite.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Solution.TestSQLite {
    public partial class App : Application {


        static SQLiteDatabase database;
        public static SQLiteDatabase Database {
            get {
                if (database == null) {
                    database = new SQLiteDatabase();
                }
                return database;
            }
        }

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListView());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
