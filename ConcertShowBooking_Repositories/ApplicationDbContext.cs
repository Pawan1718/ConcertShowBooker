using ConcertShowBooking_Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> option):base (option) 
        {
        }
        public DbSet <Venue>Venues { get; set; }
        public DbSet <Show>Shows { get; set; }
        public DbSet <Artist>Artists { get; set; }
        public DbSet <Ticket>Tickets { get; set; }
        public DbSet <Booking>Bookings { get; set; }
    }
}
