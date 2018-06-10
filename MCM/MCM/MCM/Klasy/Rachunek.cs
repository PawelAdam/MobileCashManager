using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;

namespace MCM.Klasy
{
    [Table("Rachunek")]
    public class Rachunek
    {
        [PrimaryKey, AutoIncrement]
        public int RachunekID { get; set; }
        public double Kwota { get; set; }
        public string Nazwa { get; set; }
        public string Osoba { get; set; }
        public string TypPlatnosci { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey(typeof(Kategorie))]
        public int KategoriaID { get; set; }
        [ManyToOne]
        public virtual Kategorie Kategorie { get; set; }
        public Rachunek()
        {

        }
    }
}
