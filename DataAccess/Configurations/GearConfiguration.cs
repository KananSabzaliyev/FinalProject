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
    public class GearConfiguration : IEntityTypeConfiguration<Gear>
    {
        public void Configure(EntityTypeBuilder<Gear> builder)
        {
            builder.ToTable("Gears");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE, increment: 1);
            builder.Property(x => x.GearName)
                .HasMaxLength(50);
        }
    }
}
