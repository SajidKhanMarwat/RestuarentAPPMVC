using Microsoft.EntityFrameworkCore;
using MVC_RestaurentApp.Models;

namespace MVC_RestaurentApp.Data
{
    public class MVCDemoDBContext : DbContext
    {

        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {

        }

       
        public DbSet<Dishes> Dishes { get; set; }

    }
}

