using System.Collections.Generic;
using MySqlConnector;
using Ways_DAO.Models;

namespace Ways_DAO.Repositories
{
    public class QuestionnaireRepository: BaseRepository, IRepository<Questionnaire>
    {
        public Questionnaire Create(Questionnaire element)
        {
            throw new System.NotImplementedException();
        }

        public Questionnaire FindElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Questionnaire Update(Questionnaire element)
        {
            throw new System.NotImplementedException();
        }

        public List<Questionnaire> FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}