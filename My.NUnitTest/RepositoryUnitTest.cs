using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {           
            _options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDb")
            .Options;           
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
         
            SeedData();
           
        }

        //Add Sample Data
        public async void SeedData()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
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
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            var account = await repo.GetAccountAsync(1);
            account.Should().NotBeNull();

        }
        [Test]
        public async Task GetAccounts()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            var accounts = await repo.GetAccountsAsync();
            accounts.Should().NotBeNull();
            accounts.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task InsertAccount()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            int i = await repo.AddAccountAsync(new Account { 
            Id = 0,
            Name = "Test Acount2"
            });

            i.Should().BeGreaterThan(0);
        }
        [Test]
        public async Task UpdateAccount()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
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
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            int i = await repo.DeleteAccountAsync(1);
            i.Should().BeGreaterThan(0);
        }
        #endregion
        #region Loan CRUD Test
        [Test]
        public async Task GetLoan()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            var loan = await repo.GetLoanAsync(1);
            loan.Should().NotBeNull();
        }
        [Test]
        public async Task GetLoans()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            var loans = await repo.GetLoansAsync(1);

            loans.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task InsertLoan()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
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
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
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
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            int i = await repo.DeleteLoanAsync(1);
            i.Should().BeGreaterThan(0);
        }
        #endregion
        #region Payment CRUD Test
        [Test]
        public async Task GetPayment()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            var payment = await repo.GetPaymentAsync(1);
            payment.Should().NotBeNull();
        }
        [Test]
        public async Task GetPayments()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            var payments = await repo.GetPaymentsAsync(1);

            payments.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task InsertPayment()
        {
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
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
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
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
            var repo = new MyDbRepository(new MyDbContext(_options,_configuration));
            int i = await repo.DeletePaymentAsync(1);
            i.Should().BeGreaterThan(0);
        }
        #endregion
    }
}
