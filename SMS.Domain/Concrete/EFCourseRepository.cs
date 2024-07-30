using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Abstract;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFCourseRepository : ICourseRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public EFCourseRepository(EFDbContext dbContext)
        {
            context = dbContext;
        }

        public void DeleteCourse(Course course)
        {
            context.Entry(course).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        IEnumerable<Course> ICourseRepository.GetAllCourses()
        {
            return context.Courses;
        }

        public Course GetCoursesById(int Id)
        {
            return context.Courses.Find(Id);
        }

        public void SaveCourse(Course courses)
        {
            context.Courses.Add(courses);

            context.SaveChanges();
        }

        public IEnumerable<Course> SearchCourses(string searchTerm)
        {
            var Courses = context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Courses = Courses.Where(a => a.Course_Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return Courses.ToList();
        }

        public void UpdateCourse(Course courses)
        {
            context.Entry(courses).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}