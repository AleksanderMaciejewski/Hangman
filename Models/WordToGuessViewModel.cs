namespace Hangman.Models
{
    public class WordToGuessViewModel
    {
        public WordToGuessViewModel(WordToGuess wordToGuess, int lives)
        {
            this.WordToGuess = wordToGuess;
            this.lives = lives;
            for(int i =0;i<WordToGuess.word_to_guess.Length;i++)
            {
                blank_word += "_";
            }
            this.win = false;
            this.lose = false;
        }

        public WordToGuess WordToGuess { get; set; }
        public int lives { get; set; }
        public string blank_word { get; set; }
        public  bool win { get; set; }
        public bool lose { get; set; }
    }
}
