using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public interface IUnitOfWork
    {
        IBookRepo GetBookRepo();

        IUserRepo GetUserRepo();

        ILendedBookRepo GetLendedBookRepo();

        Task SaveAsync();

        void Dispose(bool disposing);

        void Dispose();
    }
}
