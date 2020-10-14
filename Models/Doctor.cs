using System;
using System.Collections.Generic;

namespace Peohe.Models
{
    public class Doctor
    {
        public Guid DoctorId { get; set; }
        public string Name { get; set; }
        public int Cpf { get; set; }
        public int? ProfessionalRegistration { get; set; }
        public int? PhoneNumber { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public IEnumerable<ClinicDoctor> ClinicDoctors { get; set; }
        public DateTime? Deleted { get; set; }
        public string AplicationUserId { get; set; }
    }
}