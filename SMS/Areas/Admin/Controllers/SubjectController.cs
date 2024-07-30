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
    public class SubjectController : Controller
    {
        // GET: Admin/Subjects
        private readonly ISubjectRepository repository;
        public int PageSize = 10;

        public SubjectController(ISubjectRepository subjectsRepository)
        {
            this.repository = subjectsRepository;
        }
        public ActionResult Index()
        {
            SubjectListViewModel model = new SubjectListViewModel
            {
                Subjects = repository.GetAllSubjects()
            };

            return View(model);

        }
        [HttpPost]
        public JsonResult AddSubject(SubjectViewModel model)
        {
            Subject subjects = new Subject
            {
                Id = model.Id,
                Name = model.Name,
                Course_Id = model.Course_Id
            };


            repository.SaveSubject(subjects);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }
        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var subject = repository.GetSubjectById(ID);

            repository.DeleteSubject(subject);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditSubjectModel model)
        {
            var subject = repository.GetSubjectById(model.Id);

            subject.Id = model.Id;
            subject.Name = model.Name;
            subject.Course_Id = model.Course_Id;

            repository.UpdateSubject(subject);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }

        public ActionResult Details(int id)
        {
            var subject = repository.GetSubjectById(id);
            return View(subject);
        }
    }
}
