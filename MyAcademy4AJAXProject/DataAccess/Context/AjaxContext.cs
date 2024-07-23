using Microsoft.EntityFrameworkCore;
using MyAcademy4AJAXProject.DataAccess.Entities;

namespace MyAcademy4AJAXProject.DataAccess.Context
{
    public class AjaxContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ERHAN\\SQLEXPRESS;database=MyAcademy4AjaxDb;integrated security=true;trustServerCertificate=true");
        }

        public DbSet<Product> Products { get; set; }

    }
}
