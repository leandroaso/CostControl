using CostControl.Domain.Interfaces.Repositories;
using CostControl.Infra.DataContext;
using CostControl.Infra.Repositories;

namespace CostControl.Infra.Transactions
{
    public class UnityOfWork : IUnityOfWork
    {
        private CostControlContext _context;

        public UnityOfWork(CostControlContext context)
        {
            _context = context;
            this.MovementRepository = new MovementRepository(_context);
            this.DepartamentRepository = new DepartamentRepository(_context);
            this.EmployeeRepository = new EmployeeRepository(_context);
        }

        public IMovementRepository MovementRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartamentRepository DepartamentRepository { get; set; }

        public CostControlContext context {
            get {
                if (_context == null)
                    _context = new CostControlContext();
                return _context;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
