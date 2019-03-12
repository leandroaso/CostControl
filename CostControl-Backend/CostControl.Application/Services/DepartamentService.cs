using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Infra.Transactions;
using CostControl.Shared.Enums;
using CostControl.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CostControl.Application.Services
{
    public class DepartamentService : IDepartamentService
    {
        private IUnityOfWork _uow;

        public DepartamentService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public ResultModel Get(Guid Id)
        {
            var departament = _uow.DepartamentRepository.GetById(Id);

            try
            {
                return new ResultModel
                {
                    Data = departament,
                    Message = "Departamento obtido com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao buscar departamento selecionado.",
                    Status = EResultStatus.Failure
                };
            }
        }

        public IEnumerable<Departament> GetAll(int pageSize, int pageNumber)
        {
            IEnumerable<Departament> departaments;

            departaments = _uow.DepartamentRepository.GetAll()
                .OrderByDescending(x => x.CreationDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return departaments;
        }

        public ResultModel Remove(Guid Id)
        {
            try
            {
                _uow.DepartamentRepository.Delete(Id);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Message = "Departamento deletado com sucesso.",
                    Status = EResultStatus.Success
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao deletar departamento.",
                    Status = EResultStatus.Failure
                };
            }
            
        }

        public ResultModel Save(Departament entity)
        {
            if (entity.Notifications.Count > 0)
                return new ResultModel
                {
                    Data = entity.Notifications,
                    Message = "Falha ao salvar departamento.",
                    Status = EResultStatus.Failure
                };

            try
            {
                _uow.DepartamentRepository.Add(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Departamento adicionado com sucesso.",
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

        public ResultModel Update(Departament entity)
        {
            try
            {
                _uow.DepartamentRepository.Update(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Departamento atualizado com sucesso.",
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
