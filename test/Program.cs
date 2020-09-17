using Microsoft.EntityFrameworkCore;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var drawler = new ConsoleDrawler(db);
                drawler.Draw();

            }
        }
    }
}