using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.EditModels
{
    public class EditTransactionModel
    {
        public int Id { get; set; }
        public string Transaction_Name { get; set; }
        public Student Student_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
    }
}
