using HotelBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBackEnd.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Client> clients { get; set; }

    }
}
