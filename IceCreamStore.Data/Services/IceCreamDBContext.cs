using IceCreamStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStore.Data.Services
{
    public class IceCreamDBContext : DbContext
    {
        public IceCreamDBContext() : base("name=IceCreamConnectionString")
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
