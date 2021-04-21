using System.Data.Entity.ModelConfiguration;
using DataAnnotations;

namespace FluentAPI.EntityConfiguration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //name
            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);

            //description
            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            //author_id
            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            //change generated table name TagCourses to CourseTags
            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(configuration =>
                {
                    configuration.ToTable("CourseTags");
                    configuration.MapLeftKey("CourseId");
                    configuration.MapRightKey("TagId");
                });

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);
        }
    }
}
