using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Peohe.Db;
using Peohe.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Peohe.Models.Enums.Attendance;

namespace Peohe.Services
{
    public class AttendanceService
    {
        //private readonly PeoheDbContext dbContext;
        private readonly IServiceScopeFactory _scopeFactory;
        public AttendanceService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void CreateAttendance(Attendance attendance)
        {
            using (var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<PeoheDbContext>())
            {
                attendance.CreatedDate = DateTime.Now;

                if (attendance.TypeOfPayment == TypeOfPayment.Credito)
                {
                    List<Installment> installments = new List<Installment>();
                    //double amount = attendance.Amount / attendance.InstallmentsAmount.Value;
                    DateTime dueDate = DateTime.Now;

                    for (int i = 0; i < attendance.InstallmentsAmount; i++)
                    {
                        dueDate = dueDate.AddMonths(1);

                        Installment installment = new Installment()
                        {
                            InstallmentNumber = i + 1,
                            //Amount = amount,
                            DueDate = dueDate,
                            Attendance = new Attendance { AttendanceId = attendance.AttendanceId }
                        };
                        installments.Add(installment);
                    }
                    attendance.Installments = installments;
                }

                //dbContext.Entry(attendance).State = EntityState.Modified; // update or save only entity attendance
                dbContext.Attach(attendance.Clinic); // tell ef the entity Clinic already exists
                dbContext.Attendances.Add(attendance);
                dbContext.SaveChanges();
            }
        }
    }
}