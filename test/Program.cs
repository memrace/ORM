using System;
using System.Linq;
using ORM.DOMAIN;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (VotingDataContext db = new VotingDataContext())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"User {0}", user.Id);
                }
            }
        }
    }
}