using Microsoft.EntityFrameworkCore;
using My.Data.Enums;
using My.Data.Models;
using System;

namespace My.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Account>(entity =>
            {
                //Key
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                //Property
                entity.Property(x => x.Name).HasMaxLength(50);
                //Sample Data
                entity.HasData(new Account {
                Id = 1,
                Name = "Ronjun Cajilig"
                });
                                          
            });

            builder.Entity<Loan>(entity =>
            {
                //Key
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.HasIndex(x => x.AccountId).IsUnique(false);

                // Ignore field
                entity.Ignore(x => x.Payments);
                entity.Ignore(x => x.Balance);

                //Sample Data
                entity.HasData(new Loan
                {
                    Id = 1,
                    AccountId =1,
                    Date = DateTime.Now,
                    Amount = 1000,
                    IsClosed =false,
                    Status = (int)LoanStatus.Approved                   
                });

            });
            builder.Entity<Payment>(entity =>
            {
                //Key
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.HasIndex(x => x.LoanId).IsUnique(false);

                //Sample Data
                entity.HasData(new Payment
                {
                    Id = 1,
                    LoanId = 1,
                    Date = DateTime.Now,
                    Amount = 100                   
                });
            });

        }
    }
}
