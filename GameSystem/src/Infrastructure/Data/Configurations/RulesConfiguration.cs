using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.GameContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameSystem.Infrastructure.Data.Configurations;

public class RulesConfiguration : IEntityTypeConfiguration<Rules>
{
    public void Configure(EntityTypeBuilder<Rules> builder)
    {
    }
}
