using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using ShoppingList;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ShoppingList
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

