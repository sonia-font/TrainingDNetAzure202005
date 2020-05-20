using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_App.Entities
{
    public class Employee : Person
    {
        public override void GetName()
        {
            Console.WriteLine("{0} {1}", FirstName, LastName);
        }
    }
}
