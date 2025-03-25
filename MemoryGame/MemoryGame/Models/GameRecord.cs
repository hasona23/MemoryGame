namespace MemoryGame.Models
{
    public class GameRecord
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        //TODO: CHange difficulty to have enums instead
        public string Difficulty { get; set; } = "Medium";
        public DateTime PlayedAt { get; set; }
        public bool IsWon { get; set; }


    }
}
