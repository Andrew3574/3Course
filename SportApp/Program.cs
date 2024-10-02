

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
                var u = users.FirstOrDefault();
                Console.WriteLine($"{u.Login} - {u.Email}");                 

                Console.ReadLine();
                Console.Clear();

                var sortedUser = users.Where(u => u.Login!.Length < 5).FirstOrDefault();

                Console.WriteLine($"{sortedUser!.Login} - {sortedUser.Email}");
                

                Console.ReadLine();
                Console.Clear();


                var sets = db.Sets.Include(u=>u.User).ToList();

                var countSet = sets
                    .GroupBy(u=>u.User!.Login)
                    .Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    })
                    .FirstOrDefault();

                
                Console.WriteLine($"{countSet.Key} - {countSet.Count}");
                

                var vset = sets.FirstOrDefault();
                Console.WriteLine($"{vset.Name} - {vset.User!.Login}");
                

                var sortedSet = sets.Where(u => u.User!.Login!.Length < 5).FirstOrDefault();
                Console.WriteLine($"{sortedSet!.Name} - {sortedSet.User!.Login}"); 


                User user1 = new User()
                {
                    Login="qwerty",
                    Password="qwerty",
                    Email="qwrew@gmai.com"
                };

                db.Users.Add(user1);
                db.SaveChanges();

                Console.WriteLine($"Added user: {user1.Login} {user1.Email}");



                Set set1 = new Set()
                {
                    Name="qwertySet",
                    User=user1

                };

                db.Sets.Add(set1);
                db.SaveChanges();

                user1.Login = "HumanName";
                db.Users.Update(user1);
                Console.WriteLine($"Updated user: {user1.Login} {user1.Email}");

                db.Users.Remove(user1);
                db.SaveChanges();


            }


        }
    }
}
