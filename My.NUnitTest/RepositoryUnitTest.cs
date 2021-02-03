using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using My.Data;
using My.Data.Enums;
using My.Data.Models;
using My.Data.Repository;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace My.NUnitTest
{
    public class RepositoryUnitTest
    {       
        private DbContextOptions<MyDbContext> _options;
        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDb")
            .Options;          
            SeedData();
           
        }

        //Add Sample Data
        public async void SeedData()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            await repo.AddAccountAsync(new Account
            {
                Id = 1,
                Name = "Test Name"
            });

            await repo.AddLoanAsync(new Loan
            {
                Id = 1,
                AccountId = 1,
                Date = DateTime.UtcNow,
                Amount = 1000,
                IsClosed = false,
                Status = (int)LoanStatus.Approved
            });

            await repo.AddPaymentAsync(new Payment
            {
                Id = 1,
                LoanId = 1,
                Date = DateTime.UtcNow,
                Amount = 200
            });
        }

        #region Account CRUD Test
        [Test]
        public async Task GetAccount()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            var account = await repo.GetAccountAsync(1);
            account.Should().NotBeNull();

        }
        [Test]
        public async Task GetAccounts()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            var accounts = await repo.GetAccountsAsync();
            accounts.Should().NotBeNull();
            accounts.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task InsertAccount()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.AddAccountAsync(new Account { 
            Id = 0,
            Name = "Test Acount2"
            });

            i.Should().BeGreaterThan(0);
        }
        [Test]
        public async Task UpdateAccount()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.UpdateAccountAsync(new Account
            {
                Id = 1,
                Name = "Update Test Acount1"
            });

            i.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task DeleteAccount()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.DeleteAccountAsync(1);
            i.Should().BeGreaterThan(0);
        }
        #endregion
        #region Loan CRUD Test
        [Test]
        public async Task GetLoan()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            var loan = await repo.GetLoanAsync(1);
            loan.Should().NotBeNull();
        }
        [Test]
        public async Task GetLoans()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            var loans = await repo.GetLoansAsync(1);

            loans.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task InsertLoan()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.AddLoanAsync(new Loan
            {
                Id = 0,
                Date = DateTime.UtcNow,
                AccountId = 1,
                Amount =1000,
                IsClosed =false,
                Status = (int) LoanStatus.Approved
            });

            i.Should().BeGreaterThan(0);
        }
        [Test]
        public async Task UpdateLoan()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.UpdateLoanAsync(new Loan
            {
                Id = 1,
                Date = DateTime.UtcNow,
                AccountId = 1,
                Amount = 1000,
                IsClosed = false,
                Status = (int)LoanStatus.Approved
            });

            i.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task DeleteLoan()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.DeleteLoanAsync(1);
            i.Should().BeGreaterThan(0);
        }
        #endregion
        #region Payment CRUD Test
        [Test]
        public async Task GetPayment()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            var payment = await repo.GetPaymentAsync(1);
            payment.Should().NotBeNull();
        }
        [Test]
        public async Task GetPayments()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            var payments = await repo.GetPaymentsAsync(1);

            payments.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task InsertPayment()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.AddPaymentAsync(new Payment
            {
                Id = 0,
                Date = DateTime.UtcNow,               
                Amount =100            
            });

            i.Should().BeGreaterThan(0);
        }
        [Test]
        public async Task UpdatePayment()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.UpdatePaymentAsync(new Payment
            {
                Id = 1,
                Date = DateTime.UtcNow,               
                Amount = 100           
            });

            i.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task DeletePayment()
        {
            using var repo = new MyDbRepository(new MyDbContext(_options));
            int i = await repo.DeletePaymentAsync(1);
            i.Should().BeGreaterThan(0);
        }
        #endregion
    }
}
