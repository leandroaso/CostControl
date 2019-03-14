using CostControl.Domain.Entities;

namespace CostControl.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User FindUser(string username, string password);
    }
}
