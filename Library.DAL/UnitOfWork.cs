using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Repositories;

namespace Library.DAL
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : LibraryContext, new()
    {
        private TDbContext _context;
        private bool _disposed = false;

        public UnitOfWork()
        {
            _context = new TDbContext();
        }

        public IBookRepo GetBookRepo() => new BookRepo(_context);

        public IUserRepo GetUserRepo() => new UserRepo(_context);

        public ILendedBookRepo GetLendedBookRepo() => new LendedBookRepo(_context);

        public Task SaveAsync() => _context.SaveChangesAsync();

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
