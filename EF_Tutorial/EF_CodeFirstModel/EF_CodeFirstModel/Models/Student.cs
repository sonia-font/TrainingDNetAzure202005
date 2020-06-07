using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirstModel.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public int Age { get; set; }
    }
}