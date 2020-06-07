using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_ExistingDb.Models
{
    public class StudentReg
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}