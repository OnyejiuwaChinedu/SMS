using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Abstract;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFSubjectRepository : ISubjectRepository
    {

        private readonly EFDbContext context = new EFDbContext();

        public void DeleteSubject(Subject subjects)
        {
            context.Entry(subjects).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            { return context.Subjects; }
        }

        public Subject GetSubjectById(int Id)
        {
            return context.Subjects.Find(Id);
        }

        public void SaveSubject(Subject subjects)
        {

            context.Subjects.Add(subjects);

            context.SaveChanges();
        }

        public IEnumerable<Subject> SearchSubject(string searchTerm)
        {
            var Subject = context.Subjects.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Subject = Subject.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return Subject.ToList();
        }

        public void UpdateSubject(Subject subjects)
        {
            context.Entry(subjects).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
}
