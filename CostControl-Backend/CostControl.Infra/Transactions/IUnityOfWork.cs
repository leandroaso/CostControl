using CostControl.Domain.Interfaces.Repositories;
using CostControl.Infra.DataContext;
using System;

namespace CostControl.Infra.Transactions
{
    public interface IUnityOfWork : IDisposable
    {

        IMovementRepository MovementRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }
        IDepartamentRepository DepartamentRepository { get; set; }

        CostControlContext context { get; }
        void SaveChanges();
    }
}
