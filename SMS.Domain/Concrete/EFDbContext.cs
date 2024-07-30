using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
