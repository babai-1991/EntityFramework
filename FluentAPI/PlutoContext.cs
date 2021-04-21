using System.Data.Entity;
using DataAnnotations;

namespace FluentAPI
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*So note this chain of method calls,That's why we call this fluentAPI.
             It's like a fluent language. We chain method calls and it tells a story
             */

            //name
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //description
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //author_id
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c=>c.AuthorId)
                .WillCascadeOnDelete(false);

            //change generated table name TagCourses to CourseTags
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(configuration =>
                {
                    configuration.ToTable("CourseTags");
                    configuration.MapLeftKey("CourseId");
                    configuration.MapRightKey("TagId");
                });

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            base.OnModelCreating(modelBuilder);
        }
    }
}