using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetaPAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<MetaPAL.Models.SpectrumMatch>? SpectrumMatch { get; set; }
        public DbSet<MetaPAL.Models.MsDataScanModel>? MsDataScan{ get; set; }
    }
}