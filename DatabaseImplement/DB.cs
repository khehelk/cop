using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement
{
    public class DB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(@"
                    Host=localhost;
                    Port=5432;
                    Database=COP;
                    Username=postgres;
                    Password=123");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Models.Type> Types { get; set; }
    }
}