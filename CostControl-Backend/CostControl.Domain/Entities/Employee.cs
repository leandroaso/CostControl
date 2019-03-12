using CostControl.Shared.Entities;

namespace CostControl.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee(string name, Departament departament)
        {
            Name = name;
            Departament = departament;

            if(string.IsNullOrEmpty(Name) && string.IsNullOrWhiteSpace(Name))
                AddNotification("EmployeeName", "O nome não pode ser vazio ou em branco.");

            if(Name.Length > 200)
                AddNotification("EmployeeName", "O nome deve ter no máximo 200 caracteres.");
            
            if(Departament == null)
                AddNotification("Departament", "O departamento é obrigatório.");
        }
        public string Name { get; private set; }
        public Departament Departament { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}