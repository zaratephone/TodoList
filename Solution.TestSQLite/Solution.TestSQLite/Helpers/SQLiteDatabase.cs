using Solution.TestSQLite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.TestSQLite.Helpers {
    public class SQLiteDatabase {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public SQLiteDatabase() {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync() {
            if (!initialized) {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemSQLite).Name)) {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemSQLite)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<ItemSQLite>> GetItemsAsync() {
            return Database.Table<ItemSQLite>().ToListAsync();
        }

        public Task<List<ItemSQLite>> GetItemsNotDoneAsync() {            
            return Database.QueryAsync<ItemSQLite>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ItemSQLite> GetItemAsync(string id) {
            return Database.Table<ItemSQLite>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ItemSQLite item) {
            if (!string.IsNullOrEmpty(item.ID)) {
                return Database.UpdateAsync(item);
            } else {
                item.ID = Guid.NewGuid().ToString();
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ItemSQLite item) {
            return Database.DeleteAsync(item);
        }

    }
}
