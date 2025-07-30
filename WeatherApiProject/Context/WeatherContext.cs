using Microsoft.EntityFrameworkCore;
using WeatherApiProject.Entities;

namespace WeatherApiProject.Context
{
    public class WeatherContext:DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TALHA_PC\\MSSQLSERVER02;Initial Catalog=weatherDb;Integrated Security=True;TrustServerCertificate=True");

        }


      public  DbSet<City> Cities { get; set; }

    }
}
