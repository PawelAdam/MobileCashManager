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
            order.ToUpper();
            switch(order)
            {
                case "KATEGORIE": { return database.Table<Rachunek>().OrderBy(rachunek => rachunek.Kategoria).ToListAsync(); }

                case "KWOTA": { return database.Table<Rachunek>().OrderBy(rachunek => rachunek.Kwota).ToListAsync(); }

                case "OSOBA": { return database.Table<Rachunek>().OrderBy(rachunek => rachunek.Osoba).ToListAsync(); }

                case "DATA": { return database.Table<Rachunek>().OrderByDescending(rachunek => rachunek.Data).ToListAsync(); }

                default: { return database.Table<Rachunek>().ToListAsync(); }
            }
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
        public Task<int> DropTable()
        {
            return database.DropTableAsync<Rachunek>();
        }

    }
}
