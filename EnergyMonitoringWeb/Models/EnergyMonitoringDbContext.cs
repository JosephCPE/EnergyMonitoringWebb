using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoringWeb.Models
{
    public partial class EnergyMonitoringDbContext : DbContext
    {
        public EnergyMonitoringDbContext(DbContextOptions<EnergyMonitoringDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<EnergyData> EnergyData { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
