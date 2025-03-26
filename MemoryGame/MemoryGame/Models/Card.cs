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
        public static readonly List<string> cardTitles =
            ["Wand", "Stone", "Fire", "Zap", "Glasses", "Sword", "Plant", "Scar", "Broom", "Potion", "Saber", "Snake", "Venom", "Lightning"];
        private static readonly Random random = new();
        public static List<string> GetStartingDeck(Difficulty difficulty)
        {
            int deckSize = difficulty switch
            {
                Difficulty.Easy => cardTitles.Count / 4,
                Difficulty.Meduim => cardTitles.Count / 2,
                Difficulty.Hard => 3 * cardTitles.Count / 4,
                Difficulty.Extreme => cardTitles.Count,
                _ => 0
            };



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
