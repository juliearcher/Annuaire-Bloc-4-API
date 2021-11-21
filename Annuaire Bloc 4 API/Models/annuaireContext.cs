using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AnnuaireBloc4API.Models
{
    public partial class annuaireContext : DbContext
    {
        public annuaireContext()
        {
        }

        public annuaireContext(DbContextOptions<annuaireContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Site> Sites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=Bloc4API;database=annuaire", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.HasComment("A TERMINER");

                entity.HasIndex(e => e.Name, "unique name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasComment("A TERMINER - CLE ETRANGERE SERVICE SITE FAITES");

                entity.HasIndex(e => e.DepartmentsId, "SERVICES_ID");

                entity.HasIndex(e => e.SitesId, "SITES_ID");

                entity.HasIndex(e => e.Mail, "unique mail")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Surname }, "unique name/surname pair")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DepartmentsId)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("departmentsId");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(12)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");

                entity.Property(e => e.SitesId)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("sitesId");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Departments)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_1");

                entity.HasOne(d => d.Sites)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SitesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_2");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("sites");

                entity.HasIndex(e => e.City, "city")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("city");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
