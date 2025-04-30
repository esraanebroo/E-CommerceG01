using Domain.Entites.OrderEntites;

namespace Presistance.Data.Configration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o=>o.ShippingAdress, s => s.WithOwner());
            builder.HasMany(o=>o.OrderItems).WithOne();
            builder.Property(o => o.PaymentStatus).HasConversion(PaymentStatus => PaymentStatus.ToString(),
                s => Enum.Parse<OrderPaymentStatus>(s));
            builder.HasOne(o => o.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull);
            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,3)");
        }
    }
}
