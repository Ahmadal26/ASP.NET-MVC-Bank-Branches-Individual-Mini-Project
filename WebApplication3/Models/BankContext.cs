using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication3.Models;

namespace WebApplication3.Models
{
  
    public class BankContext : DbContext
    {
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BankBranch>().HasData(


            new BankBranch()
            { LocationName = "KFH Auto", LocationURL = "https://maps.app.goo.gl/cqEbKLSB8p88RLaP7", BranchManager = "Ali Mansor", EmployeeCount = 20, BankId = 1 });


            modelBuilder.Entity<Employee>()
               .HasIndex(e => e.CivilId)
               .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
    }

}
