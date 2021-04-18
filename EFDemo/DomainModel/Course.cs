using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.Enums;

namespace EFDemo.DomainModel
{
    //A tag can be applied to many courses
    // A course can have many tags
    //Many to many

    //A course can have one Author
    // An author can authored multiple courses 
    // Course and Author One to many
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public Author Author { get; set; }
        public float FullPrice { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
