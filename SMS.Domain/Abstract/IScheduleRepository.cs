using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Abstract
{
    public interface IScheduleRepository
    {

        IEnumerable<Schedule> GetAllSchedules();
        IEnumerable<Schedule> SearchSchedules(string searchTerm);
        void SaveSchedule(Schedule schedules);
        void UpdateSchedule(Schedule schedules);
        void DeleteSchedule(Schedule schedules);
        Schedule GetScheduleById(int Id);
        void Dispose();
    }
}
