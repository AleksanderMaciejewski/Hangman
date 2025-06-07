using Hangman.Models;

namespace Hangman.Services
{
    public class HangmanWordProvider
    {
        private readonly Dictionary<string, List<string>> _categories;

        private readonly Random _random;

        public HangmanWordProvider()
        {
            _random = new Random();
            _categories = new Dictionary<string, List<string>>()
        {
            { "Animals", new List<string> { "elephant", "giraffe", "penguin", "tiger", "kangaroo" } },
            { "Countries", new List<string> { "canada", "brazil", "germany", "japan", "egypt" } },
            { "Colors", new List<string> { "red", "blue", "green", "yellow", "purple" } },
            { "Food", new List<string> { "pizza", "burger", "pasta", "sushi", "salad" } },
            { "Sports", new List<string> { "soccer", "tennis", "baseball", "boxing", "Football" } }
        };
        }

        public WordToGuess GetRandomWord()
        {
            var categoryKeys = new List<string>(_categories.Keys);
            var randomCategory = categoryKeys[_random.Next(categoryKeys.Count)];

            var words = _categories[randomCategory];
            var randomWord = words[_random.Next(words.Count)];

            return new WordToGuess
            {
                category = randomCategory.ToUpper(),
                word_to_guess = randomWord.ToUpper()
            };
        }
    }
}
