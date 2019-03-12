using CostControl.Shared.Entities;

namespace CostControl.Domain.Entities
{
    public class Departament : Entity
    {
        public Departament(string name)
        {
            Name = name;

            if(string.IsNullOrEmpty(Name) && string.IsNullOrWhiteSpace(Name))
                AddNotification("DepartamentName", "O nome n�o pode ser vazio ou em branco.");

            if(Name.Length > 100)
                AddNotification("DepartamentName", "O nome deve ter no m�ximo 100 caracteres.");
        }
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}