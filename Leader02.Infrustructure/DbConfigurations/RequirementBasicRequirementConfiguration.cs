using Leader.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leader02.Infrastructure.DbConfigurations;

public class RequirementBasicRequirementConfiguration: IEntityTypeConfiguration<RequirementBasicRequirement>
{
    public void Configure(EntityTypeBuilder<RequirementBasicRequirement> builder)
    {
        builder.HasKey(x => x.Id);
    }
}