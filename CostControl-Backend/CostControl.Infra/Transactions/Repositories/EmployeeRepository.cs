using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Repositories;
using CostControl.Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CostControl.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CostControlContext _context;

        public EmployeeRepository(CostControlContext context)
        {
            _context = context;
        }

        public void Delete(Guid Id)
        {
            _context.Employees.Remove(GetById(Id));
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(Guid Id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == Id);
        }

        public void Add(Employee entity)
        {
            _context.Employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            _context.Entry<Employee>(entity).State = EntityState.Modified;
        }
    }
}
