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
    public class CourseController : Controller
    {
        // GET: Admin/Courses
        private readonly ICourseRepository repository;
        public int PageSize = 10;
        readonly Course Courses = new Course();

        public CourseController(ICourseRepository coursesRepository)
        {
            this.repository = coursesRepository;
        }
        public ActionResult Index()
        {

            CourseListViewModel model = new CourseListViewModel();

            model.Courses = repository.GetAllCourses();

            return View(model);

        }
        [HttpPost]
        public JsonResult AddCourses(CourseViewModel model)
        {
            Course courses = new Course
            {

                //courses.Id = model.Id;
                Course_Name = model.Course_Name,
                Course_Description = model.Course_Description,
                School_Year = model.School_Year
            };

            repository.SaveCourse(courses);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var courses = repository.GetCoursesById(ID);

            repository.DeleteCourse(courses);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }
        //new edit
        [HttpPost]
        public JsonResult Edited(EditCourseModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;
            if (model.Id > 0) // tyring to edit model
            {
                var courses = repository.GetCoursesById(model.Id);

                //courses.C = model.AccomodationPackageID;

                courses.Id = model.Id;
                courses.Course_Name = model.Course_Name;
                courses.Course_Description = model.Course_Description;
                courses.School_Year = model.School_Year;


                repository.UpdateCourse(courses);
            }
            else // create the record
            {
                Course courses = new Course
                {
                    Id = model.Id,
                    Course_Name = model.Course_Name,
                    Course_Description = model.Course_Description,
                    School_Year = model.School_Year
                };

                repository.SaveCourse(courses);

            }

            if (result)
            {

                json.Data = new { Success = true };
            }
            else
            {

                json.Data = new { Success = false, Message = "Unable to perform action on  Courses" };
            }

            return json;
        }
    
        public ActionResult Details(int id)
        {
            var courses = repository.GetCoursesById(id);
            return View(courses);
        }




    }
}