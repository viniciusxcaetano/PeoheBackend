using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peohe.Db;
using Peohe.Models;
using Peohe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using static Peohe.Models.Enums.Attendance;

namespace Peohe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly PeoheDbContext dbContext;
        private readonly AttendanceService attendanceService;
        public AttendanceController(PeoheDbContext context, AttendanceService attendanceService)
        {
            dbContext = context;
            this.attendanceService = attendanceService;
        }

        [HttpGet("GetAttendance")]
        public ActionResult<Attendance> GetAttendance(Guid attendanceId)
        {
            return dbContext.Attendances.Include(a => a.Installments)
                .FirstOrDefault(a => a.AttendanceId == attendanceId && a.Deleted == null);
        }

        [HttpGet("GetAttendances")]
        public ActionResult<IEnumerable<Attendance>> GetAttendances()
        {
            List<Attendance> attendances = dbContext.Attendances.Where(a => a.Deleted == null).ToList();
            return attendances;
        }

        [HttpPost("UpdateAttendance")]
        public void UpdateClinic(Attendance attendance)
        {
            Attendance oldAttendance = dbContext.Attendances.Where(a => a.AttendanceId == attendance.AttendanceId).AsNoTracking().FirstOrDefault();

            if (oldAttendance != null)
            {
                dbContext.Attendances.Update(attendance);
            }

            dbContext.SaveChanges();
        }

        [HttpPost("CreateAttendance")]
        public ActionResult<int> CreateAttendance(Attendance attendance)
        {
            //attendance.AplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                attendanceService.CreateAttendance(attendance);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("DeleteAttendance")]
        public void DeleteAttendance(Guid id)
        {
            var attendance = dbContext.Attendances.FirstOrDefault(a => a.AttendanceId == id);

            if (attendance != null)
            {
                attendance.Deleted = DateTime.Now;
                dbContext.Attendances.Update(attendance);
                dbContext.SaveChanges();
            }
        }

        [HttpPost("DeleteAttendances")]
        public void DeleteAttendances(List<Guid> ids)
        {
            List<Attendance> attendances = dbContext.Attendances.Where(a => ids.Contains(a.AttendanceId)).ToList();
            foreach (var attendance in attendances)
            {
                attendance.Deleted = DateTime.Now;
            }
            dbContext.SaveChanges();
        }

        [HttpGet("GetAttendancesPaid")]
        public ActionResult<IEnumerable<Attendance>> GetAttendancesPaid()
        {
            return dbContext.Attendances.Where(a => a.Status == Status.Pago && a.Deleted == null).ToList();
        }

        [HttpGet("GetAttendancesUnpaid")]
        public ActionResult<IEnumerable<Attendance>> GetAttendancesUnpaid()
        {
            return dbContext.Attendances.Where(a => a.Status == Status.Vencido && a.Deleted == null).ToList();
        }

        [HttpGet("GetAttendancesByMonth")]
        public ActionResult<IEnumerable<Attendance>> GetAttendancesByMonth(int? month)
        {
            return dbContext.Attendances
                .Where(a => a.CreatedDate.Month == (month.HasValue ? month : DateTime.Now.Month)
                && a.Deleted == null).ToList();
        }
    }
}