using Core.DefaultValues;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE, increment: 1);
            builder.Property(x => x.CarHp)
                .HasMaxLength(50);
            builder.Property(x => x.CarModel)
                .HasMaxLength(50);
            builder.Property(x => x.CarCondition)
                .HasMaxLength(100);
            builder.Property(x => x.CarPrice)
                .HasPrecision(7, 2);
            builder.Property(x => x.Year)
                .HasMaxLength(20);
            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200);
            builder.HasIndex(x => x.CarModel)
                .IsUnique();
            builder.HasIndex(x => new { x.CarModel, x.Deleted });

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.BranId);

            builder.HasOne(x => x.Gear)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.GearId);

            builder.HasOne(x => x.CarBody)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CarBodyId);
        }
    }
}
