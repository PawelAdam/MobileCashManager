using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MCM.Klasy
{
    public class Kategorie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Kategoria { get; set; }

        public Kategorie() { }
        public Kategorie(string kategoria)
        {
            Kategoria = kategoria;
        }
    }
}
