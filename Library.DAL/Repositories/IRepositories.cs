using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public interface IBookRepo : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> SelectListByAuthorAsync(string author);

        Task<Book> SelectByNameAndAuthorAsync(string name, string author);
    }


    public interface IUserRepo : IBaseRepository<User>
    {
        Task<IEnumerable<User>> SelectListByNameAsync(string name);

        Task<User> SelectByFioAsync(string name, string surname, string patronymic);
    }


    public interface ILendedBookRepo : IBaseRepository<LendedBook> { }
}
