using System.Configuration;
using System.Data.SqlClient;


namespace Ways_DAO.Tools
{
    public class Connection
    {
        //public static MySqlConnection New => new MySqlConnection();
        
        //public static MySqlConnection New => new MySqlConnection(ConfigurationManager.ConnectionStrings["ways_db"].ConnectionString);
        
        //public static MySqlConnection New => new MySqlConnection("server=localhost;user=root;database=ways_db;port=3306;password=root;");
        
        public static SqlConnection New { get => new SqlConnection(@"Server=JBLOUP-NB\SAGEBAT;Database=ways_db;User Id=jbloup;Password=1234;"); }
    }
}