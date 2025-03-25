using Microsoft.AspNetCore.Identity;

namespace MemoryGame.Models
{
    public class GameUser : IdentityUser
    {
        public int Score { get; set; }
        public string DisplayName { get; set; } = "";
    }
}
