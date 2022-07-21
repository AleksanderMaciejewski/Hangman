using Hangman.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Hangman.Controllers
{
    public class HangmanController : Controller
    {
        static public List<LetterViewModel> letter_list { get; set; }
        static public WordToGuess wordToGuess { get; set; }
        static public WordToGuessViewModel wordToGuessViewModel { get; set; }


        public HangmanController()
        {
            if (letter_list == null)
            {
                letter_list = new List<LetterViewModel>();
                for (char letter = 'A'; letter <= 'Z'; letter++)
                {
                    letter_list.Add(new LetterViewModel(letter.ToString()));
                }
                wordToGuess = new WordToGuess();
                wordToGuess.word_to_guess = "FOOTBALL";
                wordToGuess.category = "SPORT";
                wordToGuessViewModel = new WordToGuessViewModel(wordToGuess, 5);
            }
        }

        public IActionResult Index()
        {
            dynamic my_models = new ExpandoObject();
            my_models.modLetterViewModel = letter_list;
            my_models.modWordToGuessViewModel = wordToGuessViewModel;
            return View("Index", my_models);
        }

        public IActionResult LetterClick(string button)
        {
            foreach (var let in letter_list)
            {
                if (let.value == button)
                {
                    let.state = false;
                }
            }
            LetterCheck(button);
            dynamic my_models = new ExpandoObject();
            my_models.modLetterViewModel = letter_list;
            my_models.modWordToGuessViewModel = wordToGuessViewModel;
            return View("Index", my_models);
        }

        public void LetterCheck(string button)
        {
            if (!wordToGuess.word_to_guess.Contains(button))
            {
                wordToGuessViewModel.lives -= 1;
                if (wordToGuessViewModel.lives == 0)
                {
                    wordToGuessViewModel.lose = true;
                }

            }
            else
            {
                char[] array = wordToGuessViewModel.blank_word.ToCharArray();
                for (int i = 0; i < wordToGuess.word_to_guess.Count(); i++)
                {
                    if ((wordToGuess.word_to_guess[i].ToString() == button))
                    {
                        array[i] = wordToGuess.word_to_guess[i];
                    }
                }
                wordToGuessViewModel.blank_word = new string(array);
                if (!wordToGuessViewModel.blank_word.Contains('_'))
                {
                    wordToGuessViewModel.win = true;
                }
            }
        }

        public IActionResult NewGameClick(string new_game_button)
        {
            dynamic my_models = new ExpandoObject();
            foreach(var letter in letter_list)
            {
                letter.state = true;
            }
            my_models.modLetterViewModel = letter_list;
            wordToGuessViewModel = new WordToGuessViewModel(wordToGuess, 5);
            my_models.modWordToGuessViewModel = wordToGuessViewModel;
            return View("Index", my_models);
        }
    }
}
