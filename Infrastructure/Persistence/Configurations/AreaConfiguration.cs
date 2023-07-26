using Grupo3_Unapec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grupo3_Unapec.Infrastructure.Persistence.Configurations;

internal class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasOne(area => area.Department)
            .WithMany(department => department.Areas)
            .HasForeignKey(area => area.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}