namespace MemoryGame.Models
{
    public class Card
    {
        public string Title;
        public bool Solved;
        public Card(string title)
        {
            Title = title;

        }
        public static readonly List<string> cardTitles = ["Wand", "Stone", "Fire", "Zap", "Glasses", "Sword", "plant", "pot", "SCAR"];
        private static readonly Random random = new();
        public static List<string> GetStartingDeck(int deckSize)
        {

            deckSize = Math.Min(deckSize, cardTitles.Count);
            List<string> generatedDeck = [.. Shuffle(cardTitles).Take(deckSize)];

            generatedDeck.AddRange(generatedDeck);
            generatedDeck = Shuffle(generatedDeck);
            return generatedDeck;
        }
        public static List<T> Shuffle<T>(List<T> list)
        {
            return list.OrderBy(r => random.Next()).ToList();
        }
    }
}
