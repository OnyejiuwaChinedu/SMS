using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Abstract
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> SearchCourses(string searchTerm);
        void SaveCourse(Course courses);
        void UpdateCourse(Course courses);
        void DeleteCourse(Course courses);
        Course GetCoursesById(int Id);
        void Dispose();
    }
}
