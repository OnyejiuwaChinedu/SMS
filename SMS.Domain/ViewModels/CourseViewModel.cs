﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Course_Name { get; set; }
        public string Course_Description { get; set; }
        public string School_Year { get; set; }
    }
}