

using Microsoft.EntityFrameworkCore;
using SportApp.Models;

namespace SportApp
{
    class Program
    {
        static void Main()
        {
            SportDbContext db = new SportDbContext();

            using (db) 
            {
                var users = db.Users.ToList();
                foreach (User user in users) 
                { 
                    Console.WriteLine($"{user.Login} - {user.Email}"); 
                }

                Console.ReadLine();
                Console.Clear();

                var sortedUsers = users.Where(u => u.Login!.Length < 5);

                foreach (User user in sortedUsers)
                {
                    Console.WriteLine($"{user.Login} - {user.Email}");
                }

                Console.ReadLine();
                Console.Clear();

                var sets = db.Sets
                    .Include(u=>u.User)
                    .ToList();

                var countSets = sets
                    .GroupBy(u=>u.User!.Login)
                    .Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    });

                foreach (var set in countSets)
                {
                    Console.WriteLine($"{set.Key} - {set.Count}");
                }

                foreach (var set in sets)
                {
                    Console.WriteLine($"{set.Name} - {set.User!.Login}");
                }

                var sortedSets = sets.Where(u => u.User!.Login.Length < 5);

                foreach(var set in sortedSets)
                { Console.WriteLine($"{set.Name} - {set.User!.Login}"); }

                User user1 = new User()
                {
                    Login="qwerty",
                    Password="qwerty",
                    Email="qwrew@gmai.com"
                };

                db.Users.Add(user1);
                db.SaveChanges();

                Set set1 = new Set()
                {
                    Name="qwertySet",
                    User=user1

                };

                db.Sets.Add(set1);
                db.SaveChanges();

                db.Users.Remove(user1);
                db.SaveChanges();

            }
        }
    }
}
