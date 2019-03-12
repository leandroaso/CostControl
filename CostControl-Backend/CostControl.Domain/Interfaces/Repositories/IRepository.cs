using System;
using System.Linq;

namespace CostControl.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid Id);
        IQueryable<T> GetAll();
        T Save(T entity);
        T Update(T entity);
        void Delete(Guid Id);
    }
}
