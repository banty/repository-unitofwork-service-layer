using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SimpleOrder.Business.Models.Mapping
{
    public class OrderDeatilMap : EntityTypeConfiguration<OrderDeatil>
    {
        public OrderDeatilMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderDeatilId);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrderDeatil");
            this.Property(t => t.OrderDeatilId).HasColumnName("OrderDeatilId");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderDeatils)
                .HasForeignKey(d => d.ProductId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.OrderDeatils)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
