using Grupo3_Unapec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grupo3_Unapec.Infrastructure.Persistence.Configurations;

internal class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.OwnsOne(subject => subject.Code);

        builder.OwnsOne(subject => subject.Credits);

        builder
            .HasOne(subject => subject.Area)
            .WithMany(area => area.Subjects)
            .HasForeignKey(subject => subject.AreaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(subject => subject.Title)
            .WithMany(title => title.Subjects)
            .HasForeignKey(subject => subject.TitleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(subject => subject.TitleConfiguration)
            .WithMany(title => title.ConfigurationSubjects)
            .HasForeignKey(subject => subject.TitleConfigurationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(subject => subject.IncompatiblesSubjects)
            .WithMany()
            .UsingEntity(x => x.ToTable("IncompatibleSubject"));

        builder
            .HasMany(subject => subject.RequiredForSubjects)
            .WithMany(subject => subject.PreRequiredSubjects)
            .UsingEntity(x => x.ToTable("RequiredSubject"));

        builder
            .HasMany(subject => subject.EquivalentSubjects)
            .WithMany()
            .UsingEntity(x => x.ToTable("EquivalentSubject"));
    }
}