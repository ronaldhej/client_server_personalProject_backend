using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace personWebServer.Data
{
    public partial class personWebServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID = postgres;Password=4265;Server=localhost;Port=5432;Database=personWebServer.Dev;Integrated Security=true;Pooling=true");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity => { entity.Property<>(e => e.Url).IsRequired(); })
        }
    }
}