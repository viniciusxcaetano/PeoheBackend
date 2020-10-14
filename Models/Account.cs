using System;
using System.Collections.Generic;

namespace Peohe.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public int Cnpj { get; set; }
        public int? PhoneNumber { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public DateTime? Deleted { get; set; }
    }
}