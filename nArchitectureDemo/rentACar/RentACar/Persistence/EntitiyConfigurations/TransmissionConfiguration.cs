﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntitiyConfigurations
{
    public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.ToTable("Transmissions").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");


            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Transmissions_Name").IsUnique();


            //one to many realtionship
            builder.HasMany(b => b.Models);



            //veritabanına yapılan her sorguya bir şey eklemesini istiyoruz
            //global query filtresi  
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
