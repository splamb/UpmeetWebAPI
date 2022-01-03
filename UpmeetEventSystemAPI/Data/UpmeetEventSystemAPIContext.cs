using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UpmeetEventSystemAPI.Models;

namespace UpmeetEventSystemAPI.Data
{
    public class UpmeetEventSystemAPIContext : DbContext
    {
        public UpmeetEventSystemAPIContext (DbContextOptions<UpmeetEventSystemAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UpmeetEventSystemAPI.Models.Event> Event { get; set; }

        public DbSet<UpmeetEventSystemAPI.Models.Favorite> Favorite { get; set; }
    }
}
