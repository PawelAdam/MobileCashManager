using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Threading.Tasks;
using MCM.Klasy;

namespace MCM.Data
{
    public class RachunekDatabaseController
    {
        SQLiteAsyncConnection database;
        public RachunekDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetAsyncConnection();
            database.CreateTableAsync<Rachunek>().Wait();
        }
        public Task<List<Rachunek>> GetRachunkiAsync()
        {
            return database.Table<Rachunek>().ToListAsync();
        }
        public Task<Rachunek> GetRachunekAsync(int id)
        {
            return database.Table<Rachunek>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<List<Rachunek>> GetRachunkiSortedAsync(string order)
        {
            string query = string.Format("SELECT * FROM MCM.db3")
            return database.QueryAsync<List<Rachunek>>
        }
        public Task<int> SaveRachunek(Rachunek rachunek)
        {
            if (rachunek.Id != 0)
            {
                return database.UpdateAsync(rachunek);

            }
            else
            {
                return database.InsertAsync(rachunek);
            }
        }
        public Task<int> DeleteRachunek(Rachunek rachunek)
        {
            return database.DeleteAsync(rachunek);
        }

    }
}
