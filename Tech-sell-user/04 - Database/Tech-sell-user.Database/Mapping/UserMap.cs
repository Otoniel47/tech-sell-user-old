﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Database.Mapping
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UpdateDate);
            builder.Property(t => t.CreateDdate);
            builder.Property(t => t.Name);
            builder.Property(t => t.Email);
            builder.Property(t => t.Password);
            builder.Property(t => t.CPF);
            builder.Property(t => t.Address);
            builder.Property(t => t.City);
            builder.Property(t => t.State);
            builder.Property(t => t.Telephone);
        }
    }
}