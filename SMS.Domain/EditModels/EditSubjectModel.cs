using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.EditModels
{
    public class EditSubjectModel
    {
         
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course_Id { get; set; }
    }
}
