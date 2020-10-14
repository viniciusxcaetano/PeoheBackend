using System;

namespace Peohe.Models
{
    public class ClinicDoctor
    {
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}