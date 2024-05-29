using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Task save();
    }
}
