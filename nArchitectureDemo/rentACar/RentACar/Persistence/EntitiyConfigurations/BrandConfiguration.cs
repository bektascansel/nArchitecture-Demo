using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntitiyConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands").HasKey(b=>b.Id);

            builder.Property(b=>b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            // bu kod, "Brands" adlı bir tablodaki "Name" adlı sütuna bir indeks ekleyerek ve bu indeksi benzersiz kılarak, veritabanında markaların adlarının benzersiz olmasını sağlamak için kullanılıyor olabilir.
            builder.HasIndex(indexExpression:b=>b.Name,name:"UK_Brands_Name").IsUnique();


            //one to many realtionship
            builder.HasMany(b => b.Models);
            
            
            
            //veritabanına yapılan her sorguya bir şey eklemesini istiyoruz
            //global query filtresi  
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


        }
    }
}
