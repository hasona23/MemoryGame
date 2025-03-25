using MemoryGame.Data;
using MemoryGame.Models;
using Microsoft.AspNetCore.Identity;

namespace MemoryGame
{
    public static class DataSeeder
    {
        public static async Task SeedUsers(UserManager<GameUser> userManager)
        {
            if (userManager.Users.Any())
                return;

            Random random = new Random();

            GameUser usrBuf = new GameUser
            {
                Email = "admin123@gmail.com",
                DisplayName = "admin",
                UserName = "admin123@gmail.com",
                EmailConfirmed = true,
                Score = random.Next(0, 1001)
            };

            await userManager.CreateAsync(usrBuf, "Admin_123");

            for (int i = 0; i < 255; i++)
            {
                usrBuf = new GameUser
                {
                    Email = $"game_{i:000}@gmail.com",
                    DisplayName = $"gamer{i:000}",
                    UserName = $"game_{i:000}@gmail.com",
                    EmailConfirmed = true,
                    Score = random.Next(0, 1001)
                };
                var result = await userManager.CreateAsync(usrBuf, $"GameUser123");
                if (result.Succeeded)
                {
                    Console.WriteLine($"USER ADDED: {usrBuf.UserName}");
                }
            }


        }

        public static void SeedGames(AppDbContext appDbContext)
        {
            if (appDbContext.GameRecords.Any())
                return;
            GameRecord game;
            Random rand = new Random();
            foreach (var user in appDbContext.Users.ToList())
            {
                for (int i = 0; i < 128; i++)
                {
                    game = new GameRecord
                    {
                        Difficulty = GetRandomDifficulty(),
                        UserId = user.Id,
                        PlayedAt = new DateTime(rand.Next(1999, 2026), rand.Next(1, 13), rand.Next(1, 29)),
                        IsWon = rand.Next() % 2 == 0,
                    };
                    appDbContext.GameRecords.Add(game);

                }
            }
            appDbContext.SaveChanges();
        }
        private static string GetRandomDifficulty()
        {
            var rand = new Random();
            int value = rand.Next(0, 3);
            switch (value)
            {
                case 0:
                    return "Easy";

                case 1:
                    return "Hard";
                default:
                    return "Meduim";
            }
        }
    }
}
