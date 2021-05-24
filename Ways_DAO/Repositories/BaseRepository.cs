using MySqlConnector;

namespace Ways_DAO.Repositories
{
    public class BaseRepository
    {
        protected MySqlCommand command;
        protected MySqlDataReader reader;
        protected MySqlTransaction transaction;
        protected MySqlConnection connection;
        protected string request;
    }
}