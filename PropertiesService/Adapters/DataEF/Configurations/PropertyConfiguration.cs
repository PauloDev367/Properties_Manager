using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEF.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.MainPhoto)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.OwnsOne(x => x.Price)
            .Property(p => p.TypePropertyPayment);

        builder.OwnsOne(x => x.Price)
            .Property(p => p.Value);

        builder.HasMany(x => x.Images)
            .WithOne(i => i.Property)
            .HasForeignKey(i => i.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
