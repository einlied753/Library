using System.Data.Entity;

namespace Library.DAL
{
    internal class LibraryInit : MigrateDatabaseToLatestVersion
       <LibraryContext, Migrations.Configuration>
    {
    }
}
