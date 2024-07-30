using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Areas.Models;
using SMS.Domain.Abstract;
using SMS.Domain.EditModels;
using SMS.Domain.Entities;
using SMS.Domain.ViewModels;

namespace SMS.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository repository;
        public int PageSize = 10;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            this.repository = scheduleRepository;
        }
        // GET: Admin/Schedules
        public ActionResult Index()
        {
            ScheduleListViewModel model = new ScheduleListViewModel
            {
                Schedules = repository.GetAllSchedules()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult AddSchedule(ScheduleViewModel model)
        {
            Schedule schedules = new Schedule
            {
                Id = model.Id,
                Student_Id = model.Student_Id,
                Course_Id = model.Course_Id,
                Staff_Id = model.Staff_Id,
                Time_Start = model.Time_Start,
                End_Date = model.End_Date
            };

            repository.SaveSchedule(schedules);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var schedule = repository.GetScheduleById(ID);

            repository.DeleteSchedule(schedule);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditScheduleModel model)
        {
            var schedule = repository.GetScheduleById(model.Id);

            schedule.Id = model.Id;
            schedule.Student_Id = model.Student_Id;
            schedule.Course_Id = model.Course_Id;
            schedule.Staff_Id = model.Staff_Id;
            schedule.Time_Start = model.Time_Start;
            schedule.End_Date = model.End_Date;

            repository.UpdateSchedule(schedule);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }

        public ActionResult Details(int id)
        {
            var schedules = repository.GetScheduleById(id);
            return View(schedules);
        }
    }
}