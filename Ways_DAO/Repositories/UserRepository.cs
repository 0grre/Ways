using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Ways_DAO.Models;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public User Create(User element)
        {
            connection = Connection.New;
            
            request = "insert into `user` (`username`, `created_at`) values (@username, @createdAt)";
            command = new MySqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@username", element.UserName));
            command.Parameters.Add(new MySqlParameter("@createdAt", element.CreatedAt));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.ExecuteScalar();
            
            element.Id = (int) command.LastInsertedId;
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            
            return element;
        }

        public User FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Update(User element)
        {
            connection = Connection.New;
            
            request =
                "update `user` " +
                "set username=@username, firstname=@firstname, lastname=@lastname, birthdate=@birthdate, " +
                "description=@description, email=@email, phone=@phone, address=@address, address_complement=@addressComplement, " +
                "zip_code=@zipCode, city=@city where id=@id";

            command = new MySqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@username", element.UserName));
            command.Parameters.Add(new MySqlParameter("@firstname", element.FirstName));
            command.Parameters.Add(new MySqlParameter("@lastname", element.LastName));
            command.Parameters.Add(new MySqlParameter("@birthdate", element.BirthDate));
            command.Parameters.Add(new MySqlParameter("@description", element.Description));
            command.Parameters.Add(new MySqlParameter("@email", element.Email));
            command.Parameters.Add(new MySqlParameter("@phone", element.Phone));
            command.Parameters.Add(new MySqlParameter("@address", element.Address));
            command.Parameters.Add(new MySqlParameter("@addressComplement", element.AddressComplement));
            command.Parameters.Add(new MySqlParameter("@zipCode", element.ZipCode));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.ExecuteNonQuery();
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return element;
        }

        public List<User> FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}