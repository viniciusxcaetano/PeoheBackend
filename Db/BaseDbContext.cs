using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Peohe.Models;

namespace Peohe.Db
{
    public class BaseDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public BaseDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicDoctor> ClinicDoctors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}