using Game.Web.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Game.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Botirali",
                        LastName = "Rahmonberdiyev",
                        Gmail = "muhammmadibnabdurashid@gmail.com",
                        Login = "botir1202",
                        Password = "botir1202",
                        PhoneNumber = "+998901313126"
                    }
                );
        }

        public DbSet<Employee> employees => Set<Employee>();
    }
}
