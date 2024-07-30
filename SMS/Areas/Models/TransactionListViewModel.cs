using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Domain.Entities;

namespace SMS.Areas.Models
{
    public class TransactionListViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }

    public class TransactionActionViewModel
    {
        public int Id { get; set; }
        public string Transaction_Name { get; set; }
        public Student Student_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
    }
}
