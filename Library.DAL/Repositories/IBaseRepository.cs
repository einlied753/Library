using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Models;

namespace Library.DAL.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> SelectByIdAsync(int id);

        Task<TEntity> SelectFirstOfDefault();

        Task<IEnumerable<TEntity>> SelectListAsync();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
