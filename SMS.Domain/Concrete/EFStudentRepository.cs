using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Abstract;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public EFStudentRepository(EFDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Student> Students
        {

            get { return context.Students; }

        }

        public void SaveStudent(Student student)
        {

            context.Students.Add(student);

            context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {

            context.Entry(student).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {

            context.Entry(student).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public Student GetStudentById(int Id)
        {

            return context.Students.Find(Id);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Student> SearchStudents(string searchTerm)
        {
            var Students = context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Students = Students.Where(a => a.LastName.ToLower().Contains(searchTerm.ToLower()));
            }

            return Students.ToList();
        }

        IEnumerable<Student> IStudentRepository.GetAllStudents()
        {
            return context.Students;
        }
    }
}