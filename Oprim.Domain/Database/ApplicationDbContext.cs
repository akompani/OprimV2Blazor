using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Communications;
using Oprim.Domain.Old.Models.Communications.DecisionMinutes;
using Oprim.Domain.Old.Models.Contracting.CurrencyEscalation;
using Oprim.Domain.Old.Models.Contracting.Escalation;
using Oprim.Domain.Old.Models.Contracting.Invoices;
using Oprim.Domain.Old.Models.Contracting.ListPrices;
using Oprim.Domain.Old.Models.Contracting.Payments;
using Oprim.Domain.Old.Models.Dcc.Documents;
using Oprim.Domain.Old.Models.Dcc.DocumentTypes;
using Oprim.Domain.Old.Models.Dcc.FileManager;
using Oprim.Domain.Old.Models.Dcc.Letters;
using Oprim.Domain.Old.Models.Delay;
using Oprim.Domain.Old.Models.Organization;
using Oprim.Domain.Old.Models.Organization.Roles;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Payroll;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Cost;
using Oprim.Domain.Old.Models.PMO.Risks;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.PMO.Tailoring.Actual;
using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.Quality;
using Oprim.Domain.Old.Models.Resources;
using Oprim.Domain.Old.Models.Subcontractors;
using Oprim.Domain.Old.Models.Support;
using Oprim.Domain.Old.Models.Warehouses;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;
using Oprim.Domain.Old.Models.WorkFlow.Works;
using Oprim.Domain.Old.Security;

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
                    "Data Source=94.232.174.250;Initial Catalog=mrmetror_ppn;Integrated Security=False;User ID=mrmetror;Password=@mirTala2019;Connect Timeout=15;Encrypt=False;Packet Size=4096");
            }
        }

 

        #region Quality
        public DbSet<PunchItem> PunchItems { get; set; }
        #endregion
    }
}
