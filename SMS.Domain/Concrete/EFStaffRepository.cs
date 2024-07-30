using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Abstract;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFStaffRepository : IStaffRepository
    {

        private readonly EFDbContext context;

        public EFStaffRepository(EFDbContext dbContext)
        {
            context = dbContext; 
        }

        public void DeleteStaff(Staff staff)
        {
            context.Entry(staff).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Staff> GetAllStaffs()
        {
            return context.Staffs;
        }

        public Staff GetStaffById(int Id)
        {
            return context.Staffs.Find(Id);
        }

        public void SaveStaff(Staff staff)
        {
            context.Staffs.Add(staff);

            context.SaveChanges();
        }

        public IEnumerable<Staff> SearchStaff(string searchTerm)
        {
            var Staff = context.Staffs.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Staff = Staff.Where(a => a.Lastname.ToLower().Contains(searchTerm.ToLower()));
            }

            return Staff.ToList();
        }

        public void UpdateStaff(Staff staff)
        {
            context.Entry(staff).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
