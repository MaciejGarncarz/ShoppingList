using SQLite;

namespace ShoppingList
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

