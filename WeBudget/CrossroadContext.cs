using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget
{
    public class CrossroadContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Uslugi> Uslugis { get; set; }
    }
}