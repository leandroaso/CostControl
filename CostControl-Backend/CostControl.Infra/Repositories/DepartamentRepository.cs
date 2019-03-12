using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Repositories;
using CostControl.Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CostControl.Infra.Repositories
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private CostControlContext _context;

        public DepartamentRepository(CostControlContext context)
        {
            _context = context;
        }

        public void Delete(Guid Id)
        {
            _context.Departaments.Remove(GetById(Id));
        }

        public IQueryable<Departament> GetAll()
        {
            return _context.Departaments;
        }

        public Departament GetById(Guid Id)
        {
            return _context.Departaments.FirstOrDefault(x => x.Id == Id);
        }

        public Departament Save(Departament entity)
        {
            _context.Departaments.Add(entity);

            return entity;
        }

        public Departament Update(Departament entity)
        {
            _context.Entry<Departament>(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
