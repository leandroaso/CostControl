using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Infra.Transactions;
using CostControl.Shared.Enums;
using CostControl.Shared.Models;
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

        public IEnumerable<Movement> GetAll(int pageSize, int pageNumber)
        {
            IEnumerable<Movement> movements;

            movements = _uow.MovementRepository.GetAll()
                .OrderByDescending(x => x.CreationDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return movements;
        }

        public ResultModel Remove(Guid Id)
        {
            try
            {
                _uow.MovementRepository.Delete(Id);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Message = "Movimento deletado com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao deletar movimento.",
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
                    Message = "Falha ao adicionar movimento.",
                    Status = EResultStatus.Failure
                };

            try
            {
                _uow.MovementRepository.Add(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Movimento adicionado com sucesso.",
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
                    Message = "Movimento atualizado com sucesso.",
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
