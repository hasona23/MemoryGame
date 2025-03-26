namespace MemoryGame.Models
{
    public record GameRecordDto(DateTime PlayedAt, Difficulty Difficulty, bool IsWon);

}
