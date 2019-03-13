using CostControl.Domain.Entities;
using System.Collections.Generic;

namespace CostControl.Domain.Interfaces.Services
{
    public interface IMovementService : IService<Movement>
    {
        IEnumerable<Movement> GetAllWithPagination(int pageSize, int pageNumber);
    }
}
