using CostControl.Domain.Entities;
using CostControl.Shared.Models;

namespace CostControl.Domain.Interfaces.Services
{
    public interface IMovementService : IService<Movement>
    {
        ResultModel GetAllWithPagination(int pageSize, int pageNumber);
    }
}
