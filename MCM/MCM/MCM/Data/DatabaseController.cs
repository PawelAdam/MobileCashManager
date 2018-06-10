using MCM.Klasy;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace MCM.Data
{
    public class DatabaseController
    {
        SQLiteConnection database;
        public DatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Kategorie>();
            database.CreateTable<Rachunek>();
        }
        
        public List<Kategorie> GetKategorie()
        {
            return database.Table<Kategorie>().ToList();
        }
        public List<Rachunek> GetRachunki()
        {
            return database.Table<Rachunek>().OrderByDescending(x => x.Data).ToList();
        }
        public List<JointTables> GetJointTables()
        {
            var q = "select r.RachunekID, r.Kwota, k.KategoriaID, k.KategoriaName from Rachunek r join Kategorie k on r.KategoriaID == k.KategoriaID";
            List<JointTables> jt = database.Query<JointTables>(q).ToList();
            return jt;
        }
        public JointTables GetJointTablesByID(int id)
        {
            var q = "select r.RachunekID, r.Kwota, k.KategoriaID, k.KategoriaName from Rachunek r inner join Kategorie k on r.KategoriaID == k.KategoriaID";
            JointTables jt = database.FindWithQuery<JointTables>(q);
            return jt;
        }
        public Kategorie GetKategoria(int id)
        {
            return database.Table<Kategorie>().Where(i => i.KategoriaID == id).FirstOrDefault();
        }
        public Kategorie GetKategoriaByString(string k)
        {
            return database.Table<Kategorie>().Where(i => i.KategoriaName == k).FirstOrDefault();
        }
        public Rachunek GetRachunek(int id)
        {
            return database.Table<Rachunek>().Where(i => i.RachunekID == id).FirstOrDefault();
        }
        public int SaveRachunek(Rachunek rachunek)
        {
            if (rachunek.RachunekID != 0)
            {
                return database.Update(rachunek);
            }
            else
            {
                return database.Insert(rachunek);
            }
        }
        public int SaveKategoria(Kategorie kategoria)
        {

            if (kategoria.KategoriaID != 0)
            {
                return database.Update(kategoria);

            }
            else
            {
                return database.Insert(kategoria);
            }

        }
        public int DeleteKategoria(Kategorie kategoria)
        {

            return database.Delete<Kategorie>(kategoria.KategoriaID);

        }
        public void DropKategoriaTable()
        {
            database.DeleteAll<Kategorie>();
        }
        public void DropRachunekTable()
        {
            database.DeleteAll<Rachunek>();
        }
    }
}
