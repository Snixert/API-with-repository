using Friday.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Friday.Repository.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;" +
                "Initial Catalog=Gew;Integrated Security=True");
        }
    }
}
