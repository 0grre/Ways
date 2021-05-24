using System.Collections.Generic;

namespace Ways_DAO.Repositories
{
    public interface IRepository<T>
    {
        T Create(T element);
        T FindElementById(int id);
        T Update(T element);
        List<T> FindAll();
    }
}