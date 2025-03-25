using MemoryGame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<GameUser>(options)
    {
        public DbSet<GameRecord> GameRecords { get; set; }


    }
}
