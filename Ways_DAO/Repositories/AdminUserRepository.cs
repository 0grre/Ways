using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using Ways_DAO.Models;
using Ways_DAO.Services;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class AdminUserRepository : BaseRepository, IRepository<AdminUser>
    {

        public AdminUser Create(AdminUser element)
        {
            connection = Connection.New;
            
            request =
                $"insert into `admin_user` (`first_name`, `last_name`, `email`, `password`, `created_at`) " +
                $"values (@firstname, @lastname, @email, @password, @createdAt)";

            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@username", element.FirstName));
            command.Parameters.Add(new MySqlParameter("@username", element.LastName));
            command.Parameters.Add(new MySqlParameter("@username", element.Email));
            command.Parameters.Add(new MySqlParameter("@username", element.Password));
            command.Parameters.Add(new MySqlParameter("@createdAt", element.CreatedAt));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            //element.Id = (int) command.LastInsertedId;
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return element;
        }

        public AdminUser FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public AdminUser Update(AdminUser element)
        {
            throw new System.NotImplementedException();
        }

        public List<AdminUser> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public AdminUser GetAdminByEmail(string email)
        {
            connection = Connection.New;
            
            AdminUser adminUser = null;
            request = $"select * from `admin_user` where `email`=@email";
            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@email", email));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                adminUser = new AdminUser()
                {
                    Id = reader.SafeGet<int>(0), 
                    Password = reader.SafeGet<string>(1),
                    UserName = reader.SafeGet<string>(2),
                    FirstName = reader.SafeGet<string>(3),
                    LastName = reader.SafeGet<string>(4),
                    BirthDate = reader.SafeGet<DateTime>(5),
                    Description = reader.SafeGet<string>(6),
                    Email = reader.SafeGet<string>(7),
                    Phone = reader.SafeGet<string>(8),
                    Address = reader.SafeGet<string>(9),
                    AddressComplement = reader.SafeGet<string>(10),
                    ZipCode = reader.SafeGet<string>(11),
                    City = reader.SafeGet<string>(12),
                    CreatedAt = reader.SafeGet<DateTime>(13),
                };
            }

            reader.Close();
            command.Dispose();
            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return adminUser;
        }
    }
}