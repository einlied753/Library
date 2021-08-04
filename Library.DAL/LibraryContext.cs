using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Library.DAL.Models;

namespace Library.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryDbConnection")
        {
            Init();
        }

        protected virtual void Init()
        {
            Database.SetInitializer(new LibraryInit());
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);

            dbModelBuilder.Configurations.Add(new EntityTypeConfiguration<Book>());
            dbModelBuilder.Configurations.Add(new EntityTypeConfiguration<User>());
            dbModelBuilder.Configurations.Add(new EntityTypeConfiguration<LendedBook>());
        }
    }
}
