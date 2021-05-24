using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


using Ways_DAO.Models;
using Ways_DAO.Services;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class QuestionRepository : BaseRepository, IRepository<Question>
    {
        public Question Create(Question element)
        {
            connection = Connection.New;

            //request = $"insert into `question` (`label`, `type`, `created_at`) values (@label, @type, @createdAt)";
            request = $"insert into question (label, type, position)" +
                      $"(select '{element.Label}', '{(int) element.Type}', max(position) + 1" +
                      $"from question where type={(int) element.Type})";
            
            command = new SqlCommand(request, connection);
            
            /*command.Parameters.Add(new MySqlParameter("@type", element.Type));
            command.Parameters.Add(new MySqlParameter("@label", element.Label));*/

            if (transaction != null)
                command.Transaction = transaction;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.ExecuteScalar();
            //element.Id = (int) command.LastInsertedId;
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            //SetNewQuestionPosition(element.Id);

            return element;
        }

        // public bool SetNewQuestionPosition(int id)
        // {
        //     connection = Connection.New;
        //
        //     command = new MySqlCommand(request, connection);
        //     request = $"update `question` set `position`= max(`position`)+1 where id=@id";
        //
        //     if (transaction != null)
        //         command.Transaction = transaction;
        //
        //     command.Parameters.Add(new MySqlParameter("@id", id));
        //
        //     if (connection.State != ConnectionState.Open)
        //         connection.Open();
        //
        //     var rowsAffected = command.ExecuteNonQuery();
        //     command.Dispose();
        //
        //     if (connection.State == ConnectionState.Open && transaction == null)
        //         connection.Close();
        //
        //     return rowsAffected == 1;
        // }

        public Question FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Question Update(Question element)
        {
            throw new System.NotImplementedException();
        }

        public List<Question> FindAll()
        {
            connection = Connection.New;

            List<Question> questions = new List<Question>();
            OrientationChoiceRepository orientationChoiceRepository = new OrientationChoiceRepository();
            GameChoiceRepository gameChoiceRepository = new GameChoiceRepository();

            request = $"select * from question";

            command = new SqlCommand(request, connection);
            

            if (transaction != null)
                command.Transaction = transaction;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Question question = new Question()
                {
                    Id = reader.SafeGet<int>(0),
                    Label = reader.SafeGet<string>(1),
                    Type = (Question.QuestionTypeEnum) reader.SafeGet<int>(2),
                    Position = reader.SafeGet<int>(3),
                    CreatedAt = reader.SafeGet<DateTime>(4)
                };

                question.Choices = question.Type == Question.QuestionTypeEnum.Game
                    ? new List<Choice>(gameChoiceRepository.FindByQuestion(question))
                    : new List<Choice>(orientationChoiceRepository.FindByQuestion(question));
                questions.Add(question);
            }

            reader.Close();
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return questions;
        }

        public List<Question> FindAllByType(Question.QuestionTypeEnum type)
        {
            connection = Connection.New;

            List<Question> questions = new List<Question>();
            OrientationChoiceRepository orientationChoiceRepository = new OrientationChoiceRepository();
            GameChoiceRepository gameChoiceRepository = new GameChoiceRepository();

            request = $"select id, label, type, position, created_at from question q where q.type = @type";

            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@type", type));

            if (transaction != null)
                command.Transaction = transaction;
            
            connection.Open();
            
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question()
                    {
                        Id = reader.SafeGet<int>(0),
                        Label = reader.SafeGet<string>(1),
                        Type = (Question.QuestionTypeEnum) reader.SafeGet<int>(2),
                        Position = reader.SafeGet<int>(3),
                        CreatedAt = reader.SafeGet<DateTime>(4)
                    };

                    question.Choices = question.Type == Question.QuestionTypeEnum.Game
                        ? new List<Choice>(gameChoiceRepository.FindByQuestion(question))
                        : new List<Choice>(orientationChoiceRepository.FindByQuestion(question));
                    questions.Add(question);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            reader.Close();
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return questions;
        }
    }
}