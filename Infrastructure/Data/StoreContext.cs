using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json.Serialization;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructue.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedData(modelBuilder);

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(x=>x.PropertyType == 
                    typeof(decimal));


                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }

                

            }

            modelBuilder.ApplyConfiguration(new DeliveryMethodConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var lstTypes = JsonConvert.DeserializeObject<List<ProductType>>(ReadJsonFile("types"));
            modelBuilder.Entity<ProductType>().HasData(lstTypes);

            var lstBrands = JsonConvert.DeserializeObject<List<ProductBrand>>(ReadJsonFile("brands"));
            modelBuilder.Entity<ProductBrand>().HasData(lstBrands);
            
            var lstProducts = JsonConvert.DeserializeObject<List<Product>>(ReadJsonFile("products"));
            modelBuilder.Entity<Product>().HasData(lstProducts);

            var lstDeliveryMethods = JsonConvert.DeserializeObject<List<DeliveryMethod>>(ReadJsonFile("delivery"));
            modelBuilder.Entity<DeliveryMethod>().HasData(lstDeliveryMethods);
        }

        private string ReadJsonFile(string fileName)
        {
            using StreamReader reader = new StreamReader(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Infrastructure", "Data" , "SeedData", $"{fileName}.json"));
            string data = reader.ReadToEnd();
            return data;
        }
    }
}