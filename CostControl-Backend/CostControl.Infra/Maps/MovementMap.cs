using CostControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Infra.Maps
{
    public class MovementMap : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movement");
            builder.HasKey(x => x.Id);
        }
    }
}
