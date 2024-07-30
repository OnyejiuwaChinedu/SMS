using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Domain.Entities;

namespace SMS.Areas.Models
{
    public class CourseListViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }

    public class CourseActionViewModel
    {
        public int Id { get; set; }
        public string Course_Name { get; set; }
        public string Course_Description { get; set; }
        public string School_Year { get; set; }
    }
}
