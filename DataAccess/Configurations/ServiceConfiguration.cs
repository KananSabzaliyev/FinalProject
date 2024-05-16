using Core.DefaultValues;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            builder.Property(x=>x.Id)
                .UseIdentityColumn(seed:DefaultConstantValue.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE,increment:1);
            builder.Property(x => x.ServiceIconName)
                .HasMaxLength(200);
            builder.Property(x => x.ServiceTitle)
                .HasMaxLength(100);
            builder.Property(x => x.ServiceDescription)
                .HasMaxLength(1000);
        }
    }
}
