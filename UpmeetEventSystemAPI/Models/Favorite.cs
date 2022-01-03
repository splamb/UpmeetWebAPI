using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetEventSystemAPI.Models
{
    public class Favorite
    {
        public int FavoriteID { get; set; }
        public int EventID { get; set; }
        public string Username { get; set; }
    }
}
