using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Abstract
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAllStaffs();
        IEnumerable<Staff> SearchStaff(string searchTerm);
        void SaveStaff(Staff staff);
        void UpdateStaff(Staff staff);
        void DeleteStaff(Staff staff);
        Staff GetStaffById(int Id);
        void Dispose();
    }
}
