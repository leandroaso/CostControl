using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Infra.Transactions;
using System.Linq;

namespace CostControl.Application.Services
{
    public class UserService : IUserService
    {
        private IUnityOfWork _uow;

        public UserService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public User FindUser(string username, string password)
        {
            var user = _uow.context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            return user;
        }
    }
}
