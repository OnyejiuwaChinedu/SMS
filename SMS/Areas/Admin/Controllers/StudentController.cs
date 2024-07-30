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
using SMS.Models;

namespace SMS.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        //public StudentController() { }
        private readonly IStudentRepository repository;
        public int PageSize = 30;

        public StudentController(IStudentRepository studentRepository)
        {
            this.repository = studentRepository;
        }
        public ActionResult Index(string firstname, int page = 1)
        {

            StudentListViewModels model = new StudentListViewModels
            {
                Students = repository.GetAllStudents()
                .Where(p => firstname == null || p.FirstName == firstname)
               //.Where(p => category == null || p.Category == category)
               .OrderBy(p => p.Id)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),                                                                                                                                                                                                                                                                                                     

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = firstname == null ?
                   repository.GetAllStudents().Count() :
                   repository.GetAllStudents().Where(e => e.FirstName == firstname /* Category == category*/).Count()
                },
            };
            return View(model);

        }

        [HttpPost]
        public JsonResult AddStudent(StudentViewModel model)
        {

            Student student = new Student
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Gender = model.Gender,
                Age = model.Age,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                Password = model.Password
            };


            repository.SaveStudent(student);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int id)
        {

            var student = repository.GetStudentById(id);

            repository.DeleteStudent(student);
            
            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditStudentModels model)
        {
            var student = repository.GetStudentById(model.Id);

            student.Id = model.Id;
            student.LastName = model.LastName;
            student.FirstName = model.FirstName;
            student.Gender = model.Gender;
            student.Age = model.Age;
            student.Address = model.Address;
            student.Phone = model.Phone;
            student.Email = model.Email;
            student.Password = model.Password;


            repository.UpdateStudent(student);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });

        }
    }
}