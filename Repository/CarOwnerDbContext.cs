using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public partial class CarOwnerDbContext : DbContext
    {
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        public CarOwnerDbContext()
        {
            this.Database.EnsureCreated();
        }

        public CarOwnerDbContext(DbContextOptions<CarOwnerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("gyak")
                              .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>(carbrand => carbrand.HasMany(carbrand => carbrand.CarModels)
                                                              .WithOne(carmodel => carmodel.CarBrand)
                                                              .HasForeignKey(carmodel => carmodel.CarBrandId)
                                                              .OnDelete(DeleteBehavior.ClientSetNull));


            modelBuilder.Entity<CarModel>(carmodel => carmodel.HasOne(carmodel => carmodel.CarBrand)
                                                              .WithMany(brand => brand.CarModels)
                                                              .HasForeignKey(model => model.CarBrandId)
                                                              .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<CarModel>(carmodel => carmodel.HasMany(carmodel => carmodel.Owners));

            var brands = new List<CarBrand>()
            {
                new CarBrand(){ Id = 1, Name = "Volkswagen"},
                new CarBrand(){Id=2,Name="Audi" },
                new CarBrand(){Id=3, Name="Toyota" },
                new CarBrand(){Id=4, Name="Volvo"}
            };

            var models = new List<CarModel>()
            {
                new CarModel(){ Id=1, Name="Passat", CarBrandId=1, Price=10, OwnerId=1},
                new CarModel(){Id=2, Name ="A6", CarBrandId=2, Price=15, OwnerId=2},
                new CarModel(){Id=3, Name="GR Yaris", CarBrandId=3, Price = 20},
                new CarModel(){Id=4, Name="V70", CarBrandId=4, Price = 5}
            };

            var owners = new List<Owner>()
            {
                new Owner(){Id=1, Name="Máté"},
                new Owner(){Id=2, Name="Glória"}
            };


            modelBuilder.Entity<CarBrand>().HasData(brands);
            modelBuilder.Entity<CarModel>().HasData(models);
            modelBuilder.Entity<Owner>().HasData(owners);
        }
    }
}
