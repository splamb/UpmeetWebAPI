using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetEventSystemAPI.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Poster { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
    }
}
