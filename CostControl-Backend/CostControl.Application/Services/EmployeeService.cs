using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Infra.Transactions;
using CostControl.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CostControl.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnityOfWork _uow;

        public EmployeeService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public ResultModel Get(Guid Id)
        {
            var employee = _uow.EmployeeRepository.GetById(Id);

            try
            {
                return new ResultModel
                {
                    Data = employee,
                    Message = "Funcionário obtido com sucesso.",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao buscar funcionário selecionado.",
                    Success = false
                };
            }
            
        }

        public IEnumerable<Employee> GetAll(int pageSize, int pageNumber)
        {
            IEnumerable<Employee> employees;

            employees = _uow.EmployeeRepository.GetAll()
                .OrderByDescending(x => x.CreationDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return employees;
        }

        public ResultModel Remove(Guid Id)
        {
            try
            {
                _uow.EmployeeRepository.Delete(Id);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Message = "Funcionário deletado com sucesso.",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ResultModel
                {
                    Message = "Falha ao deletar funcionário.",
                    Success = false
                };
            }
        }

        public ResultModel Save(Employee entity)
        {
            if (entity.Notifications.Count > 0)
                return new ResultModel
                {
                    Data = entity.Notifications,
                    Message = "Falha ao adicionar funcionário.",
                    Success = false
                };

            try
            {
                _uow.EmployeeRepository.Add(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Funcionário adicionado com sucesso.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResultModel
                {
                    Data = entity,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public ResultModel Update(Employee entity)
        {
            try
            {
                _uow.EmployeeRepository.Update(entity);
                _uow.SaveChanges();

                return new ResultModel
                {
                    Data = entity,
                    Message = "Funcionário atualizado com sucesso.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResultModel
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
