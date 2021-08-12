using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected LibraryContext Context { get; private set; }

        protected DbSet<TEntity> DbSet { get; private set; }

        protected BaseRepository(LibraryContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual Task<TEntity> SelectByIdAsync(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual Task<TEntity> SelectFirstOfDefault()
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> SelectListAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Added)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }
    }
}
