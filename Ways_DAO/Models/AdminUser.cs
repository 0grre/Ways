using Ways_DAO.Models;

namespace Ways_DAO.Models
{
    public class AdminUser : User
    {
        public string Password { get; set; }

        public AdminUser()
        {
        }

        public AdminUser(string firstName, string lastName, string email, string password) : base(firstName, lastName, email)
        {
            Password = Services.Security.PasswordHash(password);
        }
    }
}