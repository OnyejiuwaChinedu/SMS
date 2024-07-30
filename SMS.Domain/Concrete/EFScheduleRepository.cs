using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Abstract;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFScheduleRepository : IScheduleRepository
    {

        private readonly EFDbContext context = new EFDbContext();

        public void DeleteSchedule(Schedule schedules)
        {
            context.Entry(schedules).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {

            return context.Schedules;

        }

        public Schedule GetScheduleById(int Id)
        {
            return context.Schedules.Find(Id);
        }

        public void SaveSchedule(Schedule schedules)
        {
            context.Schedules.Add(schedules);

            context.SaveChanges();
        }

        public IEnumerable<Schedule> SearchSchedules(string searchTerm)
        {
            var Schedules = context.Schedules.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Schedules = Schedules.Where(a => a.Id.ToString().Contains(searchTerm.ToLower()));
            }

            return Schedules.ToList();
        }

        public void UpdateSchedule(Schedule schedules)
        {
            context.Entry(schedules).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
}

