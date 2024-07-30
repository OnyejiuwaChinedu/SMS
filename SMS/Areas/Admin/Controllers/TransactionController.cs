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
    public class TransactionController : Controller
    {
        // GET: Admin/Transactions
        private readonly ITransactionRepository repository;
        public int PageSize = 10;

        public TransactionController(ITransactionRepository transactionsRepository)
        {
            this.repository = transactionsRepository;
        }
        public ActionResult Index()
        {
            TransactionListViewModel model = new TransactionListViewModel
            {
                Transactions = repository.GetAllTransactions()
            };

            return View(model);
        }
        [HttpPost]
        public JsonResult AddTransaction(TransactionViewModel model)
        {
            Transaction transaction = new Transaction
            {
                Id = model.Id,
                Transaction_Name = model.Transaction_Name,
                Student_Id = model.Student_Id,
                Transaction_Date = model.Transaction_Date
            };

            repository.SaveTransaction(transaction);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var transaction = repository.GetTransactionsById(ID);

            repository.DeleteTransaction(transaction);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditTransactionModel model)
        {
            var transaction = repository.GetTransactionsById(model.Id);

            transaction.Id = model.Id;
            transaction.Transaction_Name = model.Transaction_Name;
            transaction.Student_Id = model.Student_Id;
            transaction.Transaction_Date = model.Transaction_Date;

            repository.UpdateTransaction(transaction);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }

        public ActionResult Details(int id)
        {
            var transactions = repository.GetTransactionsById(id);
            return View(transactions);
        }
    }
}