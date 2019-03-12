using System;
using FluentValidator;

namespace CostControl.Shared.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        //Utilizado apenas para fins de ordenação
        public DateTime CreationDate { get; set; }
    }
}