using EdnaMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdnaMonitoring.App.Data.Configurations
{
    public abstract class MonitoringEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase>
    where TBase : MonitoringEntity
    {
        // https://stackoverflow.com/questions/46978332/use-ientitytypeconfiguration-with-a-base-entity
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            //Base Configuration
            builder
           .HasIndex(me => me.EdnaId)
           .IsUnique();

            builder
                .Property(me => me.IsActive)
                .HasDefaultValue(true);
        }
    }
}
