using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using Ways_DAO.Models;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class AnswerRepository : BaseRepository, IRepository<Answer>
    {
        public Answer Create(Answer element)
        {
            connection = Connection.New;
            
            request =
                $"insert into `answer` ({(element.GameChoice != null ? "`id_Game_Choice`" : "`id_Orientation_Choice`")}, `user_id`, `created_at`) " +
                $"values ({(element.GameChoice != null ? "@gameChoiceId" : "@orientationChoiceId")}, @userId, @createdAt)";

            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;
            
            var choiceParameter = element.GameChoice != null
                ? new MySqlParameter("@gameChoiceId", element.GameChoice.Id)
                : new MySqlParameter("@orientationChoiceId", element.OrientationChoice.Id);

            command.Parameters.Add(choiceParameter);
            command.Parameters.Add(new MySqlParameter("@userId", element.User.Id));
            command.Parameters.Add(new MySqlParameter("@createdAt", element.CreatedAt));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.ExecuteScalar();
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return element;
        }

        public Answer FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Answer Update(Answer element)
        {
            throw new System.NotImplementedException();
        }

        public List<Answer> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Answer> FindAll(int userId)
        {
            List<Answer> answers = new List<Answer>();
            UserRepository userRepository = new UserRepository();
            GameChoiceRepository gameChoiceRepository = new GameChoiceRepository();
            OrientationChoiceRepository orientationChoiceRepository = new OrientationChoiceRepository();

            request = $"select `user_id`, `game_choice_id`, `orientation_choice_id*` ,`a.created_at` " +
                      $"from `answer`" +
                      $"where `user_id`=@userId";

                      command = new SqlCommand(request, connection);
                      
            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@userId", userId));
            
            if (connection.State != ConnectionState.Open)
                connection.Open();
            
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Answer answer = new Answer()
                {
                    User = userRepository.FindElementById(reader.GetInt32(0)),
                    GameChoice = gameChoiceRepository.FindElementById(reader.GetInt32(1)),
                    OrientationChoice = orientationChoiceRepository.FindElementById(reader.GetInt32(2)),
                    CreatedAt = reader.GetDateTime(3)
                };
                
                answers.Add(answer);
            }

            reader.Close();
            command.Dispose();
            
            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();
            
            return answers;
        }
    }
}