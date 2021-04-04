using PaymentsApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsApp.Persistences
{
    public class PaymentPersistence : IPersistence<Payment>
    {
        readonly SQLiteAsyncConnection database;

        public PaymentPersistence(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Payment>().Wait();
        }

        public async Task<Payment> GetItemAsync(int id)
        {
            return await database.Table<Payment>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync()
        {
            return await database.Table<Payment>().ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync(int year)
        {
            //Due to a bug in the sqlite-net-pcl library or SQLite (who knows),
            //elements cannot be filtered directly from the database.
            //Logic query would be
            //return await database.Table<Payment>().Where(i => i.Date.Year == year && i.Date.Month == month).ToListAsync();
            //but this causes a 'Member access failed to compile expression' exception.
            //It seems to be a known issue for at least 4 years!
            //So, the only solution I could find was to query all the results from the table and then filter them.
            //For more information, check the next GitHub issue for reference -> https://github.com/praeclarum/sqlite-net/issues/535

            var results = await database.Table<Payment>().ToListAsync();

            return results.Where(i => i.Date.Year == year);
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync(int year, int month)
        {

            //Due to a bug in the sqlite-net-pcl library or SQLite (who knows),
            //elements cannot be filtered directly from the database.
            //Logic query would be
            //return await database.Table<Payment>().Where(i => i.Date.Year == year && i.Date.Month == month).ToListAsync();
            //but this causes a 'Member access failed to compile expression' exception.
            //It seems to be a known issue for at least 4 years!
            //So, the only solution I could find was to query all the results from the table and then filter them.
            //For more information, check the next GitHub issue for reference -> https://github.com/praeclarum/sqlite-net/issues/535

            var results = await database.Table<Payment>().ToListAsync();

            return results.Where(i => i.Date.Year == year && i.Date.Month == month);
        }

        public async Task<int> SaveItemAsync(Payment item)
        {
            if (item.ID != 0)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            return await database.Table<Payment>().DeleteAsync(i => i.ID == id);
        }
    }
}
