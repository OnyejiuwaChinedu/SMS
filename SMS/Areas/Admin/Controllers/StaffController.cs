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
    public class StaffController : Controller
    {   // GET: Admin/Staff
        private readonly IStaffRepository repository;
        public int PageSize = 10;

        public StaffController(IStaffRepository staffRepository)
        {
            this.repository = staffRepository;
        }
        public ActionResult Index()
        {

            StaffListViewModel model = new StaffListViewModel
            {
                Staffs = repository.GetAllStaffs()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult AddStaff(StaffViewModel model)
        {
            Staff staff = new Staff
            {
                Id = model.Id,
                Lastname = model.Lastname,
                FirstName = model.FirstName,
                Gender = model.Gender,
                Age = model.Age,
                Email = model.Email,
                Address = model.Address,
                Password = model.Password
            };


            repository.SaveStaff(staff);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var staff = repository.GetStaffById(ID);

            repository.DeleteStaff(staff);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditStaffModel model)
        {
            var staff = repository.GetStaffById(model.Id);

            staff.Id = model.Id;
            staff.Lastname = model.Lastname;
            staff.FirstName = model.FirstName;
            staff.Gender = model.Gender;
            staff.Age = model.Age;
            staff.Email = model.Email;
            staff.Address = model.Address;
            staff.Password = model.Password;


            repository.UpdateStaff(staff);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }

        public ActionResult Details(int id)
        {
            var staff = repository.GetStaffById(id);
            return View(staff);
        }
    }
}
