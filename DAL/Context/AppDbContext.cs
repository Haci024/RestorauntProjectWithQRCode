using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Odissey;initial catalog=OdisseyRestoraunt;integrated Security=true;TrustServerCertificate=true;");
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored);
            });
        }
        public DbSet<Category> Category { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Testimonial> Testimonials { get; set;}

        public DbSet<SocialMedia> SocialMedia { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Offers> Offers { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Features> Features { get; set; }

        

        

    }
}
