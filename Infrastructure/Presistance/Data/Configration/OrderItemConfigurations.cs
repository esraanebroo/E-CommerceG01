﻿using Domain.Entites.OrderEntites;

namespace Presistance.Data.Configration
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(o => o.Price).HasColumnType("decimal(18,3)");
            builder.OwnsOne(o=>o.Product , p => p.WithOwner());
        }
    }
}
