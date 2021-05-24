using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Ways_DAO.Models;

namespace Ways_DAO.Repositories
{
    public class ParameterRepository: BaseRepository, IRepository<Parameter>
    {
        public Parameter Create(Parameter element)
        {
            throw new System.NotImplementedException();
        }

        public Parameter FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string FindParameterValueByName(string name)
        {
            Parameter parameter = null;
            request = "select `id`, `name`, `val` from `parameter` where `name`=@name";
            command = new MySqlCommand(request, connection);
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            command.Parameters.Add(new MySqlParameter("@name", name));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                parameter = new Parameter()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Value = reader.GetString(2)
                };
            }
            reader.Close();
            command.Dispose();
            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();
            
            return parameter.Value;
        }

        public Parameter Update(Parameter element)
        {
            request = "update `parameter` set `name`=@name, `value`=@value where `id`=@id";
            command = new MySqlCommand(request, connection);
            
            if (transaction != null)
                command.Transaction = transaction;
            
            command.Parameters.Add(new MySqlParameter("@name", element.Name));
            command.Parameters.Add(new MySqlParameter("@value", element.Value));
            
            if (connection.State != ConnectionState.Open)
                connection.Open();
            
            command.ExecuteNonQuery();
            command.Dispose();
            
            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();
            
            return element;
        }

        public List<Parameter> FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}