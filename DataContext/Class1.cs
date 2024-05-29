
using Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<Apartment> Apartments { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public async Task save()
        {
          await  SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.UrlImages)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-UJ06G94\SQLEXPRESS;database=finalProjectA;trusted_connection=true;");
        }

    }
}
