using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ways_DAO.Models;
using Ways_DAO.Services;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public User Create(User element)
        {
            connection = Connection.New;
            
            request = "insert into `user` (`username`, `created_at`) values (@username, @createdAt)";
            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new SqlParameter("@username", element.UserName));
            command.Parameters.Add(new SqlParameter("@createdAt", element.CreatedAt));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.ExecuteScalar();
            
            //element.Id = (int) command.LastInsertedId;
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            
            return element;
        }

        public User FindElementById(int id)
        {
            connection = Connection.New;
            
            User user = null;
            request = $"select * from `user` where id=@userId";
            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new SqlParameter("@userId", id));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new User()
                {
                    Id = reader.SafeGet<int>(0),
                    UserName = reader.SafeGet<string>(1),
                    FirstName = reader.SafeGet<string>(2),
                    LastName = reader.SafeGet<string>(3),
                    BirthDate = reader.SafeGet<DateTime>(4),
                    Description = reader.SafeGet<string>(5),
                    Email = reader.SafeGet<string>(6),
                    Phone = reader.SafeGet<string>(7),
                    Address = reader.SafeGet<string>(8),
                    AddressComplement = reader.SafeGet<string>(9),
                    ZipCode = reader.SafeGet<string>(10),
                    City = reader.SafeGet<string>(11),
                    CreatedAt = reader.SafeGet<DateTime>(12),
                };
            }

            reader.Close();
            command.Dispose();
            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return user;
        }

        public User Update(User element)
        {
            connection = Connection.New;
            
            request =
                "update `user` " +
                "set username=@username, firstname=@firstname, lastname=@lastname, birthdate=@birthdate, " +
                "description=@description, email=@email, phone=@phone, address=@address, address_complement=@addressComplement, " +
                "zip_code=@zipCode, city=@city where id=@id";

            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new SqlParameter("@username", element.UserName));
            command.Parameters.Add(new SqlParameter("@firstname", element.FirstName));
            command.Parameters.Add(new SqlParameter("@lastname", element.LastName));
            command.Parameters.Add(new SqlParameter("@birthdate", element.BirthDate));
            command.Parameters.Add(new SqlParameter("@description", element.Description));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            command.Parameters.Add(new SqlParameter("@phone", element.Phone));
            command.Parameters.Add(new SqlParameter("@address", element.Address));
            command.Parameters.Add(new SqlParameter("@addressComplement", element.AddressComplement));
            command.Parameters.Add(new SqlParameter("@zipCode", element.ZipCode));

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