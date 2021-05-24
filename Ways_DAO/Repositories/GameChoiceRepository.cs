using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ways_DAO.Models;
using Ways_DAO.Services;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class GameChoiceRepository: BaseRepository, IRepository<GameChoice>
    {
        public GameChoice Create(GameChoice element)
        {
            throw new System.NotImplementedException();
        }

        public GameChoice FindElementById(int id)
        {
            connection = Connection.New;
            
            GameChoice gameChoice = null;
            request = $"select * from `game_choice` where id=@gameChoiceId";
            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            command.Parameters.Add(new SqlParameter("@gameChoiceId", id));

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                gameChoice = new GameChoice()
                {
                    Id = reader.SafeGet<int>(0),
                    Label = reader.SafeGet<string>(0),
                    ValueInPoints = reader.SafeGet<int>(0),
                    CreatedAt = reader.SafeGet<DateTime>(12),
                };
            }

            reader.Close();
            command.Dispose();
            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return gameChoice;
        }

        public GameChoice Update(GameChoice element)
        {
            throw new System.NotImplementedException();
        }

        public List<GameChoice> FindAll()
        {
            throw new System.NotImplementedException();
        }
        
        public List<Choice> FindByQuestion(Question question)
        {
            connection = Connection.New;

            List<Choice> gameChoices = new List<Choice>();

            request = $"select gc.* from game_choice gc where gc.id_Question = {question.Id}";

            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Choice gameChoice = new Choice()
                {
                    Id = reader.SafeGet<int>(0),
                    Label = reader.SafeGet<string>(1),
                    CreatedAt = reader.SafeGet<DateTime>(3),
                    Question = question
                };

                
                gameChoices.Add(gameChoice);
            }

            reader.Close();
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return gameChoices;
        }
    }
}