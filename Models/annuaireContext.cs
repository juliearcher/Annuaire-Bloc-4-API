using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Annuaire_Bloc_4_API.Models
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

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Service> Services { get; set; }
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

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasComment("A TERMINER - CLE ETRANGERE SERVICE SITE FAITES");

                entity.HasIndex(e => e.ServicesId, "ServicesId");

                entity.HasIndex(e => e.SitesId, "SitesId");

                entity.HasIndex(e => e.Mail, "unique mail")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Surname }, "unique name/surname pair")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mail")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("mobile")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("phone")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ServicesId)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("SERVICES_ID");

                entity.Property(e => e.SitesId)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("SITES_ID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_1");

                entity.HasOne(d => d.Sites)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SitesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_2");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

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
