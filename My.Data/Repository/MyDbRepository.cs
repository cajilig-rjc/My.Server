﻿using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class MyDbRepository : IMyDbRepository
    {
        private readonly MyDbContext _context;
        public MyDbRepository(MyDbContext context)
        {
            _context = context;
        }
        public IAccountRepository AccountRepository => new AccountRepository(_context);

        public ILoanRepository LoanRepository => new LoanRepository(_context);

        public IPaymentRepository PaymentRepository => new PaymentRepository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);

        public async Task AddAsync<T>(T entity)
        {
           await _context.AddAsync(entity);           
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
          
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update<T>(T entity)
        {
            _context.Update(entity);          
           
        }
    }
}
