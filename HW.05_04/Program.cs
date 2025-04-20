using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var oldestUser = context.Users
                .OrderByDescending(u => u.Age)
                .FirstOrDefault();

            Console.WriteLine("👴 Найстарший користувач:");
            Console.WriteLine($"{oldestUser.FullName}, {oldestUser.Age} років");

            Console.WriteLine("\n📅 Три останніх зареєстрованих користувача:");
            var recentUsers = context.Users
                .OrderByDescending(u => u.RegisteredAt)
                .Take(3)
                .ToList();

            foreach (var user in recentUsers)
            {
                Console.WriteLine($"{user.FullName} — {user.RegisteredAt.ToShortDateString()}");
            }

            Console.WriteLine("\n🧾 Ролі та кількість користувачів:");
            var roleStats = context.Roles
                .Select(r => new
                {
                    r.RoleName,
                    UserCount = r.Users.Count
                })
                .ToList();

            foreach (var stat in roleStats)
            {
                Console.WriteLine($"{stat.RoleName} — {stat.UserCount} користувачів");
            }
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
