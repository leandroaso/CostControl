using CostControl.Shared.Entities;

namespace CostControl.Domain.Entities
{
    public class Movement : Entity
    {
        public Movement(Employee employee, string description, decimal movementValue)
        {
            Employee = employee;
            Description = description;
            MovementValue = movementValue;

            if(Employee == null)
                AddNotification("Employee", "O funcion�rio � obrigat�rio.");
            
            if(string.IsNullOrEmpty(Description) && string.IsNullOrWhiteSpace(Description))
                AddNotification("Description", "A descri��o n�o pode ser vazia ou em branco.");

            if(Description.Length > 500)
                AddNotification("Description", "A descri��o deve ter no m�ximo 500 caracteres.");
        }
        public Employee Employee { get; private set; }
        public string Description { get; private set; }
        public decimal MovementValue { get; private set; }

        public override string ToString()
        {
            return $"Employee responsible: {Employee}, Movement value: {MovementValue} and description: {Description}";
        }
    }
}