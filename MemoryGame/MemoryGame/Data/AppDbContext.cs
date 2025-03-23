using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MemoryGame.Models;

namespace MemoryGame.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<GameUser>(options)
    {
    }
}
