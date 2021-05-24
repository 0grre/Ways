using System.Configuration;
using MySqlConnector;

namespace Ways_DAO.Tools
{
    public class Connection
    {
        //public static MySqlConnection New => new MySqlConnection();
        
        //public static MySqlConnection New => new MySqlConnection(ConfigurationManager.ConnectionStrings["ways_db"].ConnectionString);
        public static MySqlConnection New => new MySqlConnection("server=localhost;user=root;database=ways_db;port=3306;password=;");
    }
}