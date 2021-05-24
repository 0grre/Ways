using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Ways_DAO.Models;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class AnswerRepository : BaseRepository, IRepository<Answer>
    {
        public Answer Create(Answer element)
        {
            request =
                $"insert into `answer` (`game_choice_id`, `orientation_choice_id`, `questionnaire_id`, `created_at`) " +
                "values (@gameChoiceId, @orientationChoiceId, @questionnaireId, @createdAt)";

            command = new MySqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@gameChoiceId", element.GameChoice.Id));
            command.Parameters.Add(new MySqlParameter("@orientationChoiceId", element.OrientationChoice.Id));
            command.Parameters.Add(new MySqlParameter("@questionnaireId", element.Questionnaire.Id));
            command.Parameters.Add(new MySqlParameter("@createdAt", element.CreatedAt));

            if (connection.State != ConnectionState.Open)
                connection.Open();

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

        public List<Answer> FindAll(int questionnaireId)
        {
            List<Answer> answers = new List<Answer>();
            QuestionnaireRepository questionnaireRepository = new QuestionnaireRepository();
            GameChoiceRepository gameChoiceRepository = new GameChoiceRepository();
            OrientationChoiceRepository orientationChoiceRepository = new OrientationChoiceRepository();

            request = $"select `questionnaire_id`, `game_choice_id`, `orientation_choice_id*` ,`a.created_at` " +
                      $"from `answer`" +
                      $"where `questionnaire_id`=@questionnaireId";

                      command = new MySqlCommand(request, connection);
                      
            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new MySqlParameter("@questionnaireId", questionnaireId));
            
            if (connection.State != ConnectionState.Open)
                connection.Open();
            
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Answer answer = new Answer()
                {
                    Questionnaire = questionnaireRepository.FindElementById(reader.GetInt32(0)),
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