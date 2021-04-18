using System;
using System.Collections.Generic;

namespace EFDemo.DomainModel
{
   //A tag can be applied to many courses
   // A course can have many tags
   //Many to many
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}