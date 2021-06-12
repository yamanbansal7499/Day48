using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ex01Day48.Models
{
    public partial class yamDbContext : DbContext
    {
        public yamDbContext()
        {
        }

        public yamDbContext(DbContextOptions<yamDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:yamanserver.database.windows.net,1433;Initial Catalog=yamDb;Persist Security Info=False;User ID=admin246;Password=admin@246;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Salary__AF2DBB99BADD87A6");

                entity.Property(e => e.Da)
                    .HasColumnName("DA")
                    .HasComputedColumnSql("((0.05)*[BasicSalary])");

                entity.Property(e => e.Hra)
                    .HasColumnName("HRA")
                    .HasComputedColumnSql("((0.10)*[BasicSalary])");

                entity.Property(e => e.InHandSalary).HasComputedColumnSql("(((([BasicSalary]+(0.10)*[BasicSalary])+(0.05)*[BasicSalary])+(0.05)*[BasicSalary])-(0.10)*[BasicSalary])");

                entity.Property(e => e.NetSalary).HasComputedColumnSql("((([BasicSalary]+(0.10)*[BasicSalary])+(0.05)*[BasicSalary])+(0.05)*[BasicSalary])");

                entity.Property(e => e.Payband)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ta)
                    .HasColumnName("TA")
                    .HasComputedColumnSql("((0.05)*[BasicSalary])");

                entity.Property(e => e.Tds)
                    .HasColumnName("TDS")
                    .HasComputedColumnSql("((0.10)*[BasicSalary])");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
