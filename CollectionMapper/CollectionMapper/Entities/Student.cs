using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionMapper.Entities
{
    public class Student : Person
    {        
        public string Class { get; set; }
        public string Seat { get; set; }
        public string Club { get; set; }
        public string Persona { get; set; }
        public string Crush { get; set; }
        public string LockerSize { get; set; }
        public string Strength { get; set; }        
        public string Stockings { get; set; }
        public string Accessory { get; set; }
        public string ScheduleTime { get; set; }
        public string ScheduleDestination { get; set; }
        public string ScheduleAction { get; set; }
        public string Info { get; set; }
    }
}
