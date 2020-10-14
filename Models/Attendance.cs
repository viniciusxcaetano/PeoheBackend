using System;
using System.Collections.Generic;
using static Peohe.Models.Enums.Attendance;

namespace Peohe.Models
{
    public class Attendance
    {
        public Attendance() { }
        public Guid AttendanceId { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public string Description { get; set; }
        public TypeOfPayment? TypeOfPayment { get; set; }
        public double? Amount { get; set; }
        public double? AmountPaid { get; set; }
        public double? Percentage { get; set; }
        public double? CardFee { get; set; }
        public int? InstallmentsAmount { get; set; }
        public int? InstallmentsPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PayDay { get; set; }
        public DateTime? Deleted { get; set; }
        public IEnumerable<Installment> Installments { get; set; }
        public Clinic Clinic { get; set; }
        public Doctor Doctor { get; set; }
        public string AplicationUserId { get; set; }
    }
}