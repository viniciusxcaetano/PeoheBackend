using Microsoft.AspNetCore.Identity;
using System;

namespace Peohe.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Account Account { get; set; }
        public DateTime? Deleted { get; set; }
    }
}