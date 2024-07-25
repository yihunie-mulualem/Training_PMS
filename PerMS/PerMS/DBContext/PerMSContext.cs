using Microsoft.EntityFrameworkCore;
using PerMS.Models;
namespace PerMS.DBContext
{
    public class PerMSContext: DbContext
    {
     
        public PerMSContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BussinesUnit> BussinesUnits { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HeadQuarterlyPms> HeadQuarterlyPms { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Role> Roles { get; set; }
     //   public DbSet<District_Division> District_Divisions { get; set; }
        public DbSet<MonthlyPmsWeight> MonthlyPmsWeights { get; set; }
        public DbSet<User> Users { get; set; }//Employee_Approve
        public DbSet<HierarchyGroup> HierarchyGroups { get; set; }
        public DbSet<Employee_Approve> Employee_Approves { get; set; }//Employee_Approve MonthlyPmsWeight
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
             .HasOne(e => e.HierarchyGroup)
             .WithMany(h => h.Employees)
             .HasForeignKey(e => e.HierarchyGroupId)
             .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobPosition)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobPositionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.BussinesUnit)
                .WithMany(b => b.Employees)
                .HasForeignKey(e => e.BussinesUnitId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
