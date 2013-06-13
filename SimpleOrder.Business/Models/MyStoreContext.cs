using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SimpleOrder.Business.Models.Mapping;

namespace SimpleOrder.Business.Models
{
    public partial class MyStoreContext : DbContext
    {
        static MyStoreContext()
        {
            Database.SetInitializer<MyStoreContext>(null);
        }

        public MyStoreContext()
            : base("Name=MyStoreContext")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDeatil> OrderDeatils { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDeatilMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
