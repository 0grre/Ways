using System.Collections.Generic;
using MySqlConnector;
using Ways_DAO.Models;

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
            throw new System.NotImplementedException();
        }

        public GameChoice Update(GameChoice element)
        {
            throw new System.NotImplementedException();
        }

        public List<GameChoice> FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}