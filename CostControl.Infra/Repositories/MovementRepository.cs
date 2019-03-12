using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Repositories;
using CostControl.Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CostControl.Infra.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private CostControlContext _context;

        public MovementRepository(CostControlContext context)
        {
            _context = context;
        }

        public void Delete(Guid Id)
        {
            _context.Movements.Remove(GetById(Id));
        }

        public IQueryable<Movement> GetAll()
        {
            return _context.Movements;
        }

        public Movement GetById(Guid Id)
        {
            return _context.Movements.FirstOrDefault(x => x.Id == Id);
        }

        public Movement Save(Movement entity)
        {
            _context.Movements.Add(entity);

            return entity;
        }

        public Movement Update(Movement entity)
        {
            _context.Entry<Movement>(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
