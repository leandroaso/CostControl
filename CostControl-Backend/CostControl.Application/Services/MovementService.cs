using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Infra.Transactions;
using CostControl.Shared.Enums;
using CostControl.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CostControl.Application.Services
{
    public class MovementService : IMovementService
    {
        private IUnityOfWork _uow;

        public MovementService(IUnityOfWork uow)
        {
            _uow = uow;
        }
        public ResultModel Get(Guid Id)
        {
            var movement = _uow.MovementRepository.GetById(Id);

            try
            {
                return new ResultModel
                {
                    Data = movement,
                    Message = "Movimento obtido com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao buscar movimento selecionado.",
                    Status = EResultStatus.Failure
                };
            }
        }

        public IEnumerable<Movement> GetAll()
        {
            IEnumerable<Movement> movements;

            movements = _uow.MovementRepository.GetAll()
                .AsNoTracking()
                .Include(x => x.Employee)
                .OrderByDescending(x => x.CreationDate)
                .ToList();

            return movements;
        }

        public ResultModel GetAllWithPagination(int pageSize, int pageNumber)
        {
            try
            {
                IEnumerable<Movement> movements;

                movements = _uow.MovementRepository.GetAll()
                    .AsNoTracking()
                    .OrderByDescending(x => x.CreationDate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var movementsLength = _uow.context.Movements
                    .AsNoTracking().Count();

                var movementsFormatted = new { movements = movements, length = movementsLength };

                return new ResultModel
                {
                    Data = movementsFormatted,
                    Message = "Movimentações obtidas.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception ex)
            {

                return new ResultModel
                {
                    Message = ex.Message,
                    Status = EResultStatus.Failure
                };
            }
            
        }

        public ResultModel Remove(Guid Id)
        {
            try
            {
                _uow.MovementRepository.Delete(Id);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Message = "Movimentação deletada com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao deletar movimentação.",
                    Status = EResultStatus.Failure
                };
            }
        }

        public ResultModel Save(Movement entity)
        {
            if (entity.Notifications.Count > 0)
                return new ResultModel
                {
                    Data = entity.Notifications,
                    Message = "Falha ao adicionar movimentação.",
                    Status = EResultStatus.Failure
                };

            try
            {
                _uow.MovementRepository.Add(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Movimentação adicionada com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new ResultModel
                {
                    Data = entity,
                    Message = ex.Message,
                    Status = EResultStatus.Failure
                };
            }
        }

        public ResultModel Update(Movement entity)
        {
            try
            {
                _uow.MovementRepository.Update(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Movimentação atualizada com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new ResultModel
                {
                    Message = ex.Message,
                    Status = EResultStatus.Failure
                };
            }
        }
    }
}
