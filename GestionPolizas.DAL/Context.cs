namespace GestionPolizas.DAL
{
    using GestionPolizas.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public partial class Context : DbContext
    {
        private static bool created = false;

        public Context()
        {
            if (!created)
            {
                created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite("Filename=GestionPolizas.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionbuilder);
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPolicy> CustomerPolicy { get; set; }
        public virtual DbSet<IdentificationType> IdentificationType { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<PolicyType> PolicyType { get; set; }
        public virtual DbSet<RiskType> RiskType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdentificationType)
                      .IsRequired();
                entity.Property(e => e.IdentificationNumber)
                      .IsRequired();
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasOne(c => c.Identification)
                      .WithMany(i => i.Customers)
                      .HasForeignKey(c => c.IdentificationType)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomerPolicy>(entity =>
            {
                entity.Property(e => e.Active)
                      .IsRequired();
                entity.Property(e => e.BeginningValidity)
                      .IsRequired();
                entity.Property(e => e.CustomerId)
                      .IsRequired();
                entity.Property(e => e.PolicyId)
                      .IsRequired();

                entity.HasOne(c => c.Policy)
                      .WithMany(i => i.CustomerPolicies)
                      .HasForeignKey(c => c.PolicyId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(c => c.Customer)
                      .WithMany(i => i.CustomersPolicies)
                      .HasForeignKey(c => c.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Active);
                entity.Property(e => e.Name)
                      .IsRequired();
                entity.HasData(
                    new IdentificationType { Id = 1, Name = "CC", Description = "Cedula Ciudadania", Active = true },
                    new IdentificationType { Id = 2, Name = "NIT", Description = "NIT", Active = true }
                    );
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Active);
                entity.Property(e => e.Name)
                      .IsRequired();
                entity.Property(e => e.Price)
                      .IsRequired();
                entity.Property(e => e.Coverage)
                      .IsRequired();

                entity.HasOne(c => c.PolicyType)
                      .WithMany(i => i.Policies)
                      .HasForeignKey(c => c.PolicyTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(c => c.RiskType)
                      .WithMany(i => i.Policies)
                      .HasForeignKey(c => c.RiskTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PolicyType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Active)
                      .IsRequired();
                entity.Property(e => e.Name)
                      .IsRequired();
                entity.HasData(
                    new PolicyType { Id = 1, Name = "Terremoto", Description = "Poliza que cubre terremoto", Active = true },
                    new PolicyType { Id = 2, Name = "Incendio", Description = "Poliza que cubre incendio", Active = true },
                    new PolicyType { Id = 3, Name = "Robo", Description = "Poliza que cubre robo", Active = true },
                    new PolicyType { Id = 4, Name = "Perdida", Description = "Poliza que cubre perdida", Active = true }
                    );
            });

            modelBuilder.Entity<RiskType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Active)
                      .IsRequired();
                entity.Property(e => e.Name)
                      .IsRequired();
                entity.HasData(
                    new RiskType { Id = 1, Name = "bajo", Description = "riesgo bajo", Active = true },
                    new RiskType { Id = 2, Name = "medio", Description = "riesgo medio", Active = true },
                    new RiskType { Id = 3, Name = "medio-alto", Description = "riesgo medio alto", Active = true },
                    new RiskType { Id = 4, Name = "alto", Description = "riesgo alto", Active = true }
                );
            });
        }
    }
}
