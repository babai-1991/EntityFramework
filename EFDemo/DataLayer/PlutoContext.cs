using System.Data.Entity;
using EFDemo.DomainModel;

namespace EFDemo.DataLayer
{
    public class PlutoContext : DbContext
    {
        public PlutoContext():base("name=MyPlutoDatabase")
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
