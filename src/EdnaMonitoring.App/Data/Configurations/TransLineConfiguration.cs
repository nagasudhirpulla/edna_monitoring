using EdnaMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdnaMonitoring.App.Data.Configurations
{
    public class TransLineConfiguration : MonitoringEntityConfiguration<TransLine>
    {
        public override void Configure(EntityTypeBuilder<TransLine> builder)
        {
            base.Configure(builder);
            builder
               .HasIndex(tl => new { tl.Name, tl.Substation })
               .IsUnique();
        }
    }
}
