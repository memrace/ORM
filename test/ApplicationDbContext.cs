using Microsoft.EntityFrameworkCore;

namespace test
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        
        public DbSet<Speech> Speeches { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }

        public ApplicationDbContext()
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=1234;database=mysql;");
        }
    }
}