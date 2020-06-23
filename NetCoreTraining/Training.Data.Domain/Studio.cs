using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Data.Domain
{
    public class Studio : Entity<Guid>
    {
        public string Name { get; set; }

    }
}
