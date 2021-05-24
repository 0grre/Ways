using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

using Ways_DAO.Models;
using Ways_DAO.Repositories;
using Ways_DAO.Tools;

namespace Ways_DAO.Services
{
    public class Security
    {
        public static string PasswordHash(string password)
        {
            // creating salt value
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // getting the hash value with Rfc2898DeriveBytes
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // combining salt and password bytes
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool PasswordVerify(string password, string passwordHash)
        {
            // get bytes
            byte[] hashBytes = Convert.FromBase64String(passwordHash);

            // get salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // compute the hash with the password to verify
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // compare
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    throw new ArgumentException("wrong password");
                }
            }

            return true;
        }

        public static AdminUser Login(string email, string password)
        {
            AdminUserRepository adminUserRepository = new AdminUserRepository();
            AdminUser admin;

            try
            {
                admin = adminUserRepository.GetAdminByEmail(email);
                if (admin is null) throw new ArgumentException("wrong email");
                PasswordVerify(password, admin.Password);
            }
            catch (ArgumentException e)
            {
                throw;
            }
            catch (SqlException e)
            {
                throw;
            }

            return admin;
        }
    }
}