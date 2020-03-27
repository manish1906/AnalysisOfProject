using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Company.Models
{
    public partial class SoftwareCompanyDBContext : DbContext
    {
        public SoftwareCompanyDBContext()
        {
        }

        public SoftwareCompanyDBContext(DbContextOptions<SoftwareCompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignProject> AssignProject { get; set; }
        public virtual DbSet<BussinessUnits> BussinessUnits { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OnVacation> OnVacation { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<VAssignProject> VAssignProject { get; set; }
        public virtual DbSet<VProjectDetails> VProjectDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=manishparmar\\SQLExpress;Database=SoftwareCompanyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignProject>(entity =>
            {
                entity.HasKey(e => e.AssignId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssignProject)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignProject_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssignProject)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignProject_Projects");
            });

            modelBuilder.Entity<BussinessUnits>(entity =>
            {
                entity.HasKey(e => e.BussinessUnitId);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OnVacation>(entity =>
            {
                entity.HasKey(e => e.VacationId);

              //  entity.Property(e => e.VacationId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OnVacation)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnVacation_Employees");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bussiness)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.BussinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_BussinessUnits");
            });

            modelBuilder.Entity<VAssignProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAssignProject");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AssignId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VProjectDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vProjectDetails");

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
                entity.Property(e => e.ProjectId)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
                entity.Property(e => e.UnitName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
