using ContractMonthlyClaimSystem.HR.Models;
using Microsoft.EntityFrameworkCore;

namespace ContractMonthlyClaimSystem.HR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
