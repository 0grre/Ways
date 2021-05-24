using System.Data.SqlClient;


namespace Ways_DAO.Repositories
{
    public class BaseRepository
    {
        protected SqlCommand command;
        protected SqlDataReader reader;
        protected SqlTransaction transaction;
        protected SqlConnection connection;
        protected string request;
    }
}