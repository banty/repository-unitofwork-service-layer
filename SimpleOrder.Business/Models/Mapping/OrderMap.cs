using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SimpleOrder.Business.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.OrderedBy)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.OrderedBy).HasColumnName("OrderedBy");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
        }
    }
}
