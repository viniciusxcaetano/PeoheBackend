using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peohe.Models;

namespace Peohe.Db.Configuration
{
    public class ClinicDoctorConfiguration : IEntityTypeConfiguration<ClinicDoctor>
    {
        public void Configure(EntityTypeBuilder<ClinicDoctor> builder)
        {
            //Table
            builder.ToTable("ClinicDoctor");
            //Key
            builder.HasKey(cldc => new { cldc.ClinicId, cldc.DoctorId });
        }
    }
}