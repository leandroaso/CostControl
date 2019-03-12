using CostControl.Shared.Models;
using System;
using System.Collections.Generic;

namespace CostControl.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll(int pageSize, int pageNumber);
        ResultModel Get(Guid Id);
        ResultModel Save(T entity);
        ResultModel Update(T entity);
        ResultModel Remove(Guid Id);
    }
}
