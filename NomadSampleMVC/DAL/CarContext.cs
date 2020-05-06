using NomadSampleMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NomadSampleMVC.DAL
{
    public class CarContext : DbContext
    {
        public CarContext() : base("name=MyCarsDBConnectionString")
        {
        }

        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}