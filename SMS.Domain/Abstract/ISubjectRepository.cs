using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Abstract
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects();
        IEnumerable<Subject> SearchSubject(string searchTerm);
        void SaveSubject(Subject subjects);
        void UpdateSubject(Subject subjects);
        void DeleteSubject(Subject subjects);
        Subject GetSubjectById(int Id);
        void Dispose();
    }
}
