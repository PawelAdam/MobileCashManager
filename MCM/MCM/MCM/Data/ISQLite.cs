using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MCM.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
