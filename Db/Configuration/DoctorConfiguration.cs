using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peohe.Models;
using System;

namespace Peohe.Db.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            //Table
            builder.ToTable("Doctor");

            //Key
            builder.HasKey(doctor => doctor.DoctorId);

            //Identity
            builder.Property(doctor => doctor.DoctorId).HasDefaultValue(Guid.NewGuid());

            //Fields
            builder.Property(doctor => doctor.Name);
            builder.Property(doctor => doctor.Cpf);
            builder.Property(doctor => doctor.ProfessionalRegistration);
            builder.Property(doctor => doctor.PhoneNumber);
            builder.Property(doctor => doctor.Deleted);
            builder.Property(doctor => doctor.AplicationUserId);
        }
    }
}