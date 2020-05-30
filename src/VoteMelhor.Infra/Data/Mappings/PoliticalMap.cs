using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PoliticalMap : IEntityTypeConfiguration<Political>
    {
        public void Configure(EntityTypeBuilder<Political> builder)
        {
            builder.ToTable("Political");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();            

            builder.Property(c => c.FullName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.State)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnType("varchar(100)")
                .HasMaxLength(12)
                .IsRequired();

             builder.HasMany(c => c.PoliticalPartys)
                .WithOne(c => c.Political)
                .HasForeignKey(c => c.PoliticalId);

            builder.HasMany(c => c.LawSuits)
               .WithOne(c => c.Political)
               .HasForeignKey(c => c.PoliticalId);

            builder.HasMany(c => c.Votings)
               .WithOne(c => c.Political)
               .HasForeignKey(c => c.PoliticalId);

            builder.HasMany(c => c.Ratings)
               .WithOne(c => c.Political)
               .HasForeignKey(c => c.PoliticalId);

            builder.HasMany(c => c.Positions)
               .WithOne(c => c.Political)
               .HasForeignKey(c => c.PoliticalId);
        }
    }
}
