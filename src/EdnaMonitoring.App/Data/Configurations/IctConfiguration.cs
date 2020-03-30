using EdnaMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdnaMonitoring.App.Data.Configurations
{
    public class IctConfiguration : MonitoringEntityConfiguration<Ict>
    {
        public override void Configure(EntityTypeBuilder<Ict> builder)
        {
            base.Configure(builder);
        }
    }
}
