using Microsoft.EntityFrameworkCore;

namespace ORM.DOMAIN
{
    public class VotingDataContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        
        

        public VotingDataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=1234;database=mysql;");
        }
    }
}