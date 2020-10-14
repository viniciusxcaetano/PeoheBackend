using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peohe.Models;
using System;

namespace Peohe.Db.Configuration
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            //Table
            builder.ToTable("Clinic");

            //Key
            builder.HasKey(clinic => clinic.ClinicId);

            //Identity
            builder.Property(clinic => clinic.ClinicId).HasDefaultValue(Guid.NewGuid());

            //Fields
            builder.Property(clinic => clinic.Name);
            builder.Property(clinic => clinic.Percentage);
            builder.Property(clinic => clinic.Address);
            builder.Property(clinic => clinic.Comments);
            builder.Property(clinic => clinic.Phone);
            builder.Property(clinic => clinic.Deleted);
            builder.Property(clinic => clinic.AplicationUserId);
        }
    }
}