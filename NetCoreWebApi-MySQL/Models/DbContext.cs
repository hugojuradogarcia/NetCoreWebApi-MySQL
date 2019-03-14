using Microsoft.EntityFrameworkCore;

namespace NetCoreWebApi_MySQL.Models
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public StudentContext(DbContextOptions options) : base(options) { }
    }
}
