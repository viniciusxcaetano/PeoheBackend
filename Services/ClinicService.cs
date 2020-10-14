using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Peohe.Db;
using Peohe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peohe.Services
{
    public class ClinicService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public ClinicService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void DeleteClinic(List<Guid> ids)
        {
            using (var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<PeoheDbContext>())
            {
                try
                {
                    List<Clinic> clinics = dbContext.Clinics.Where(c => ids.Contains(c.ClinicId)).ToList();

                    foreach (var clinic in clinics)
                    {
                        clinic.Deleted = DateTime.Now;
                    }
                    dbContext.SaveChanges();

                }
                catch (Exception)
                {
                }
            }
        }
    }
}
