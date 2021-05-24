using MySqlConnector;

namespace Ways_DAO.Services
{
    public static class Database
    {
        public static T SafeGet<T>(this MySqlDataReader reader, int col)
        {
            return reader.IsDBNull(col) ? default(T) : reader.GetFieldValue<T>(col);
        }
    }
}