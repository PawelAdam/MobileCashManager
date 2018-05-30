using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using MCM.Klasy;

namespace MCM.Data
{
    public class KategorieDatabaseController
    {
        SQLiteAsyncConnection database;
        public KategorieDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetAsyncConnection();
            database.CreateTableAsync<Kategorie>().Wait();
        }
        public Task<List<Kategorie>> GetKategorieAsync()
        {
            return database.Table<Kategorie>().ToListAsync();
        }
        public Task<Kategorie> GetKategoriaAsync(int id)
        {
            return database.Table<Kategorie>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveKategoria(Kategorie kategoria)
        {

            if (kategoria.ID != 0)
            {
                return database.UpdateAsync(kategoria);

            }
            else
            {
                return database.InsertAsync(kategoria);
            }

        }
        public Task<int> DeleteKategoria(Kategorie kategoria)
        {

            return database.DeleteAsync(kategoria);

        }

    }
}

