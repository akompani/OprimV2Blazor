using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Entities.Quality;
using Oprim.Domain.Old.Models.Organization;

namespace Oprim.Domain.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=185.2.14.61\\MSSQLSERVER2019;Initial Catalog=oprim_alkoa;Integrated Security=False;User ID=oprim_test;Password=Oprim2024;Connect Timeout=15;Encrypt=False;Packet Size=4096");
            }
        }

 

        #region Quality
        public DbSet<PunchItem> PunchItems { get; set; }
        #endregion
    }
}
