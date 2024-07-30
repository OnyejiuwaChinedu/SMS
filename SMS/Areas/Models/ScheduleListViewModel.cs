using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Domain.Entities;

namespace SMS.Areas.Models
{
    public class ScheduleListViewModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }
    }
    public class ScheduleActionViewModel
    {
        public int Id { get; set; }
        public string Student_Id { get; set; }
        public string Course_Id { get; set; }
        public string Staff_Id { get; set; }
        public DateTime Time_Start { get; set; }
        public DateTime End_Date { get; set; }
    }
}
