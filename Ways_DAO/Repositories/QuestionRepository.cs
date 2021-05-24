using System.Collections.Generic;
using MySqlConnector;
using Ways_DAO.Models;

namespace Ways_DAO.Repositories
{
    public class QuestionRepository: BaseRepository, IRepository<Question>
    {
        public Question Create(Question element)
        {
            throw new System.NotImplementedException();
        }

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
            throw new System.NotImplementedException();
        }
    }
}