namespace Hangman.Models
{
    public class LetterViewModel
    {
        public LetterViewModel(string value)
        {
            this.value = value;
            this.state = true;
        }
        public string value { get; set; }
        public bool state { get; set; }
    }
}
