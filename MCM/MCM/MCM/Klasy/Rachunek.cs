using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MCM.Klasy
{
    
    public class Rachunek
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Kategoria { get; set; }
        public double Kwota { get; set; }
        public string Nazwa { get; set; }
        public string Osoba { get; set; }
        public string TypPlatnosci { get; set; }
        public DateTime Data { get; set; }
        public Rachunek() { }
        public Rachunek(string kategoria, double kwota, string nazwa, string osoba, string typPlatnosci)
        {
            Kategoria = kategoria;
            Kwota = Math.Round(kwota,2);
            Nazwa = nazwa;
            Osoba = osoba;
            TypPlatnosci = typPlatnosci;
            Data = DateTime.Today;
        }




    }
}
