using Grupo3_Unapec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grupo3_Unapec.Infrastructure.Persistence.Configurations;

internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.OwnsOne(teacher => teacher.Name);

        builder.OwnsOne(teacher => teacher.Office);

        builder.OwnsMany(teacher => teacher.Schedules);

        builder.HasOne(teacher => teacher.Area)
            .WithMany(area => area.Teachers)
            .HasForeignKey(teacher => teacher.AreaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(teacher => teacher.Subjects)
            .WithMany(subject => subject.Teachers);
    }
}