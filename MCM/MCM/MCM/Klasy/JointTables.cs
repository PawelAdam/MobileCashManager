using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MCM.Klasy
{
    [Table("JointTables")]
    public class JointTables
    {
        [ForeignKey(typeof(Kategorie))]
        public int KategoriaID { get; set; }
        [ForeignKey(typeof(Rachunek))]
        public int RachunekID { get; set; }
        public double Kwota { get; set; }
        public string KategoriaName { get; set; }
    }
}
