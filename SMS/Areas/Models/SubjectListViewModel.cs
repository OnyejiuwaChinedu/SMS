using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Domain.Entities;

namespace SMS.Areas.Models
{
    public class SubjectListViewModel
    {
        public IEnumerable<Subject> Subjects { get; set; }
    }
    public class SubjectActionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course_Id { get; set; }
    }
}
