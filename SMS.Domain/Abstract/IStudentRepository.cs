using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        //IEnumerable<Student> GetAllStudents { get; }
        IEnumerable<Student> SearchStudents(string searchTerm);
        void SaveStudent(Student students);
        void UpdateStudent(Student students);
        void DeleteStudent(Student students);
        Student GetStudentById(int Id);
        void Dispose();
    }
}
