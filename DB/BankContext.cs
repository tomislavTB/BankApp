using BankApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using BankApp.Extensions;
using System.Threading.Tasks;
using System.Threading;

namespace BankApp.DB
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        { }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Saving> Savings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            base.OnModelCreating(modelBuilder);
            // unique key 
            modelBuilder.Entity<Client>()
                .HasIndex(p => new { p.FirstName, p.LastName, p.Email, p.IBAN })
                .IsUnique(true);
            // unique key 
            modelBuilder.Entity<Bank>()
                .HasIndex(p => new { p.Name, p.IBAN })
                .IsUnique(true);

            // many-to-many for 
            // relationship is: client - saving - bank
         
            modelBuilder.Entity<Saving>()
                .HasOne<Client>(sc => sc.Client)
                .WithMany(s => s.Savings)
                .HasForeignKey(sc => sc.ClientId);


            modelBuilder.Entity<Saving>()
                .HasOne<Bank>(sc => sc.Bank)
                .WithMany(s => s.Savings)
                .HasForeignKey(sc => sc.BankId);

            // seed data from Extensions/Seeds.cs
            modelBuilder.Seed();
        }
        // used for tracking columns
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is BaseModel)
                {
                    var now = DateTime.UtcNow;
                    BaseModel entity = (BaseModel)entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                    }
                }
            }
        }















    }





    
}
