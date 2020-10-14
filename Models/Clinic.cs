using System;
using System.Collections.Generic;

namespace Peohe.Models
{
    public class Clinic
    {
        public Guid ClinicId { get; set; }
        public string Name { get; set; }
        public double? Percentage { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public string Phone { get; set; }
        public IEnumerable<ClinicDoctor> ClinicDoctors { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public DateTime? Deleted { get; set; }
        public string AplicationUserId { get; set; }
    }
}