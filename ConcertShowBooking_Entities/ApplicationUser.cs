using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
    }
}
