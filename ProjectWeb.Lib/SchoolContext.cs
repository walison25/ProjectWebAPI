using Microsoft.EntityFrameworkCore;
using ProjectWeb.Lib.Models;

namespace ProjectWeb.Lib
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Data Source=PR1NBKMI11\SQLEXPRESS;Initial Catalog=SchoolDB;Persist Security Info=True;User ID=admin123;Password=admin123");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   //         modelBuilder.Entity<Teacher>().HasKey(sc => new { sc.DepartamentName, sc.IdTeacher });

        }
    }
}
