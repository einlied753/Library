using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal class BookRepo : BaseRepository<Book>, IBookRepo
    {
        internal BookRepo(LibraryContext context) : base(context) { }

        public async Task<IEnumerable<Book>> SelectListByAuthorAsync(string author)
        {
            return await DbSet.AsNoTracking().Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task<Book> SelectByNameAndAuthorAsync(string name, string author)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }
    }


    internal class UserRepo : BaseRepository<User>, IUserRepo
    {
        internal UserRepo(LibraryContext context) : base(context) { }

        public async Task<IEnumerable<User>> SelectListByNameAsync(string name)
        {
            return await DbSet.AsNoTracking().Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task<User> SelectByFioAsync(string name, string surname, string patronymic)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && u.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase) && u.Patronymic.Equals(patronymic, StringComparison.OrdinalIgnoreCase));
        }
    }


    internal class LendedBookRepo : BaseRepository<LendedBook>, ILendedBookRepo
    {
        internal LendedBookRepo(LibraryContext context) : base(context) { }
    }
}
