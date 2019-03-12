using CostControl.Shared.Entities;
using System;

namespace CostControl.Domain.Entities
{
    public class Employee : Entity
    {
        protected Employee()
        {

        }

        public Employee(string name, Departament departament)
        {
            Name = name;
            Departament = departament;

            if(string.IsNullOrEmpty(Name) && string.IsNullOrWhiteSpace(Name))
                AddNotification("EmployeeName", "O nome n�o pode ser vazio ou em branco.");

            if(Name.Length > 200)
                AddNotification("EmployeeName", "O nome deve ter no m�ximo 200 caracteres.");
            
            if(DepartamentId == null)
                AddNotification("DepartamentId", "O departamento � obrigat�rio.");
        }
        public string Name { get; private set; }
        public Guid DepartamentId { get; set; }
        public Departament Departament { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}