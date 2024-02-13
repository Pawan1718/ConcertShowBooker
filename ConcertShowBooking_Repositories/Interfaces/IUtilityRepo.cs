using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task<string>SaveImage(string ContainerName, IFormFile file);
        Task<string>EditImage(string ContainerName, IFormFile file,string dbPath);
        Task<string>DeleteImage(string ContainerName, string dbPath);
    }
}
