using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peohe.Models;
using System;

namespace Peohe.Db.Configuration
{
    public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            //Table
            builder.ToTable("Installment");

            //Key
            builder.HasKey(installment => installment.InstallmentId);

            //Identity
            builder.Property(installment => installment.InstallmentId).HasDefaultValue(Guid.NewGuid());

            //Fields
            builder.Property(installment => installment.Amount);
            builder.Property(installment => installment.Paid);
            builder.Property(installment => installment.InstallmentNumber);
            builder.Property(installment => installment.DueDate);
            builder.Property(installment => installment.PayDay);
            builder.Property(installment => installment.Deleted);
            builder.Property(installment => installment.Historic);
            builder.Property(installment => installment.AplicationUserId);
        }
    }
}