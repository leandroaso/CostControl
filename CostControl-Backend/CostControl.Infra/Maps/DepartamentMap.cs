using CostControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Infra.Maps
{
    public class DepartamentMap : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.ToTable("Departament");
            builder.HasKey(x => x.Id);
        }
    }
}
