using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Windows.Input;

namespace MCM.Klasy
{
    [Table("Kategorie")]
    public class Kategorie
    {
        [PrimaryKey, AutoIncrement]
        public int KategoriaID { get; set; }
        public string KategoriaName { get; set; }
        [OneToMany]
        public virtual List<Rachunek> Rachinki { get; set; }

        public Kategorie()
        {

        }
        public override int GetHashCode()
        {
            return KategoriaID;
        }
        
    }
}
