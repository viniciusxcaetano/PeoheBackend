using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peohe.Models;
using System;

namespace Peohe.Db.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //Table
            builder.ToTable("Account");

            //Key
            builder.HasKey(account => account.AccountId);

            //Identity
            builder.Property(account => account.AccountId).HasDefaultValue(Guid.NewGuid());

            //Property
            builder.Property(account => account.Deleted);
            builder.Property(account => account.Name);
            builder.Property(account => account.Cnpj);
            builder.Property(account => account.PhoneNumber);
            builder.Property(account => account.Logo);
        }
    }
}