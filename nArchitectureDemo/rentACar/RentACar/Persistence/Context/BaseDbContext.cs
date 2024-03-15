using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration  Configuration { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
           // Database.EnsureCreated(); //önce veritabanının oluştuğundan emin ol

        }

        //veritabanı ile ilgili confıgurationların yapıldığı yerdir
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //git mevcut assembly (entityConfigurations) içerisindeki configurationları bul onları uygula 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    }
}
