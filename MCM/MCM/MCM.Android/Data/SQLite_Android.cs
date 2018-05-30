using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System.IO;
using MCM.Data;
using MCM.Droid.Data;
using SQLite;

[assembly: Dependency(typeof(SQLite_Android))]

namespace MCM.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteAsyncConnection GetAsyncConnection()
        {
            var sqliteFileName = "MCM.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteAsyncConnection(path);

            return conn;
        }
    }
}