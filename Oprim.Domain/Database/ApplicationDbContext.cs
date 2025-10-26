using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Entities.Cost;
using Oprim.Domain.Entities.Identity;
using Oprim.Domain.Entities.Organization;
using Oprim.Domain.Entities.PMO;
using Oprim.Domain.Entities.Quality;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Domain.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
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
                    "Data Source=185.2.14.61\\MSSQLSERVER2022;Initial Catalog=oprim_test_blazor;Integrated Security=False;User ID=oprim_blazor;Password=Blazor2025;Connect Timeout=15;Encrypt=False;Packet Size=4096");
            }
        }

        #region Organization

        public DbSet<StakeholderGroup> StakeholderGroups { get; set; }
        public DbSet<Stakeholder> Stakeholders { get; set; }
        public DbSet<OrganizationRole> OrganizationRoles { get; set; }

        #endregion

        #region PMO

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectItemGroup> ProjectItemGroups { get; set; }
        public DbSet<ProjectItem> ProjectItems { get; set; }

        #endregion

        #region Cost

        public DbSet<ProjectCostBreakdown> ProjectCostBreakdowns { get; set; }

        #endregion

        #region Quality

        public DbSet<PunchItem> PunchItems { get; set; }

        #endregion

        #region WorkFlow

        public DbSet<WorkTemplate> WorkTemplates { get; set; }
        public DbSet<WorkTemplateArticle> WorkTemplateArticles { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkArticle> WorkArticles { get; set; }

        #endregion
    }
}