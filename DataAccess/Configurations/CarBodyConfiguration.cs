using Core.DefaultValues;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class CarBodyConfiguration : IEntityTypeConfiguration<CarBody>
    {
        public void Configure(EntityTypeBuilder<CarBody> builder)
        {
            builder.ToTable("CarBodies");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE, increment: 1);
            builder.Property(x => x.CarBodyName)
                .HasMaxLength(50);
        }
    }
}
