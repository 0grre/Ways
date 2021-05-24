using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ways_DAO.Models;
using Ways_DAO.Services;
using Ways_DAO.Tools;

namespace Ways_DAO.Repositories
{
    public class OrientationChoiceRepository : BaseRepository, IRepository<OrientationChoice>
    {
        public OrientationChoice Create(OrientationChoice element)
        {
            throw new System.NotImplementedException();
        }

        public OrientationChoice FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public OrientationChoice Update(OrientationChoice element)
        {
            throw new System.NotImplementedException();
        }

        public List<OrientationChoice> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Choice> FindByQuestion(Question question)
        {
            connection = Connection.New;

            List<Choice> orientationChoices = new List<Choice>();

            request = $"select oc.* from orientation_choice oc where oc.id_Question = {question.Id}";

            command = new SqlCommand(request, connection);

            if (transaction != null)
                command.Transaction = transaction;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Choice orientationChoice = new Choice()
                {
                    Id = reader.SafeGet<int>(0),
                    Label = reader.SafeGet<string>(1),
                    CreatedAt = reader.SafeGet<DateTime>(2),
                    Question = question
                };

                orientationChoices.Add(orientationChoice);
            }

            reader.Close();
            command.Dispose();

            if (connection.State == ConnectionState.Open && transaction == null)
                connection.Close();

            return orientationChoices;
        }
    }
}