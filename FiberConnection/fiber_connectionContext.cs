using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeAPI.FiberConnection
{
    public partial class fiber_connectionContext : DbContext
    {
        public fiber_connectionContext()
        {
        }

        public fiber_connectionContext(DbContextOptions<fiber_connectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = tcp:fiberplan.database.windows.net, 1433; Initial Catalog = fiberconnection; Persist Security Info = False; User ID = team3; Password = Bdgs@007; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.EmployeeMail)
                    .IsUnicode(false)
                    .HasColumnName("Employee_mail");

                entity.Property(e => e.EmployeePassword)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("Employee_password");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkLocation).IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).IsUnicode(false);

                entity.Property(e => e.EmployeePhonenumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.PlanName).IsUnicode(false);

                entity.Property(e => e.Status1)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Status__Employee__30C33EC3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
