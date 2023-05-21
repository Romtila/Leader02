using Leader.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leader02.Infrastructure.DbConfigurations;

public class SubDepartmentConfiguration : IEntityTypeConfiguration<SubDepartment>
{
    public void Configure(EntityTypeBuilder<SubDepartment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DepartmentUsers)
            .WithOne(x => x.SubDepartment)
            .HasForeignKey(x => x.SubDepartmentId);

        builder.HasMany(x => x.ConsultationSlots)
            .WithOne(x => x.SubDepartment)
            .HasForeignKey(x => x.SubDepartmentId);
    }
}