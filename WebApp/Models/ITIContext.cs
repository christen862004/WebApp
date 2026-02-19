using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Department>  Department { get; set; }

        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }
        //compatablity
        public ITIContext() : base()
        {

        }
        //DbContext options  "DBMS - server name- auth - database name"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=M9M46;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //base.OnModelCreating(builder);//<--identity Updat database
        //}
    }
}
