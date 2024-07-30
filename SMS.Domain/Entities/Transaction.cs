using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Transaction_Name { get; set; }
        public Student Student_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
    }
}
