using System;

namespace Ways_DAO.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressComplement { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {
        }

        public User(string userName)
        {
            UserName = userName;
            CreatedAt = DateTime.Now;
        }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = DateTime.Now;
        }
    }
}