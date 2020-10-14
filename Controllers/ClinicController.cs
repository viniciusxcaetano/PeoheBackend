using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peohe.Db;
using Peohe.Models;
using Peohe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Peohe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly PeoheDbContext dbContext;
        private readonly ClinicService clinicService;
        public ClinicController(PeoheDbContext context, ClinicService clinicService)
        {
            dbContext = context;
            this.clinicService = clinicService;
        }

        [HttpGet("GetClinic")]
        public ActionResult<Clinic> GetClinic(Guid id)
        {
            return dbContext.Clinics.FirstOrDefault(c => c.ClinicId == id && c.Deleted == null);
        }

        [HttpGet("GetClinics")]
        public ActionResult<IEnumerable<Clinic>> GetClinics()
        {
            List<Clinic> clinics = dbContext.Clinics.Where(c => c.Deleted == null).ToList();

            return clinics;
        }

        [HttpGet("GetClinicNameList")]
        public ActionResult<IEnumerable<Clinic>> GetClinicNameList()
        {
           var test =  dbContext.Clinics.Where(c => c.Deleted == null)
                .Select(c =>
                new Clinic
                {
                    ClinicId = c.ClinicId,
                    Name = c.Name
                }).ToList();

            return test;
        }

        [HttpPost("CreateClinic")]
        public void CreateClinic(Clinic clinic)
        {
            //clinic.AplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            dbContext.Clinics.Add(clinic);
            dbContext.SaveChanges();
        }
        [HttpPost("UpdateClinic")]
        public void UpdateClinic(Clinic clinic)
        {
            Clinic oldClinic = dbContext.Clinics
                .Where(c => c.ClinicId == clinic.ClinicId).AsNoTracking().FirstOrDefault();

            if (oldClinic != null)
            {
                dbContext.Clinics.Update(clinic);
            }

            dbContext.SaveChanges();
        }

        [HttpGet("DeleteClinic")]
        public void DeleteClinic(Guid id)
        {
            var clinic = dbContext.Clinics.FirstOrDefault(c => c.ClinicId == id);
            if (clinic != null)
            {
                clinic.Deleted = DateTime.Now;
                dbContext.Clinics.Update(clinic);
                dbContext.SaveChanges();
            }
        }

        [HttpPost("DeleteClinics")]
        public void DeleteClinics(List<Guid> ids)
        {
            List<Clinic> clinics = dbContext.Clinics.Where(c => ids.Contains(c.ClinicId)).ToList();

            foreach (var clinic in clinics)
            {
                clinic.Deleted = DateTime.Now;
            }
            dbContext.SaveChanges();
        }
    }
}