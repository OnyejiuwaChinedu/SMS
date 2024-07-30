using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Domain.Entities;

namespace SMS.Areas.Models
{
    public class StaffListViewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
    }

    public class StaffActionViewModel
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
