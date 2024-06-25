namespace Projects;

using System.Text;
using Spectre.Console;

public class GuessingGame
{
    public void Play()
    {
        Dictionary<string, string> words = new Dictionary<string, string>
        {
            { "Python", "Created by Guido Van Rossum" },
            { "Java", "Created by James Gosling" },
            { "Javascript", "Brendan Eich" },
            { "SQL", "Raymond F Vaice" },
            { "C", "Dennis Ritchie" }
        };

        int lives = 5;
        bool winGame = false;
        bool correctPrediction = false;
        int randIndex = new Random().Next(1, words.Count());
        List<string> keys = words.Keys.ToList();
        string randomKey = keys[randIndex];

        void reduceLives()
        {
            if (lives < 1)
            {
                Console.WriteLine("You Lost, Try again");
            }
            lives--;
            Console.WriteLine("You lost a live");
        }

        StringBuilder sb = new StringBuilder("", randIndex);
        for (int i = 0; i < randomKey.Length; i++)
        {
            sb.Append(Emoji.Known.RedQuestionMark);
        }

        bool fillChar(char ch)
        {
            if (randomKey.Contains(ch))
            {
                for (int i = 0; i < randomKey.Length; i++)
                {
                    if (randomKey[i] == ch)
                    {
                        sb[i] = ch;
                    }
                }
                return true;
            }
            return false;
        }

        bool checkInput(string word)
        {
            if (word.Length < 2)
            {
                char ch = word[0];
                if (!fillChar(ch))
                {
                    return false;
                }
                return true;
            }
            if (!String.IsNullOrEmpty(word))
            {
                if (
                    (word.ToString() == randomKey.ToString())
                    || (word.ToLower().ToString() == randomKey.ToLower().ToString())
                )
                {
                    correctPrediction = true;
                    return true;
                }
                return false;
            }
            return false;
        }

        while (!winGame)
        {
            if (lives < 1)
            {
                AnsiConsole.MarkupLine(
                    Emoji.Known.CrossMarkButton + "[red bold] You Lost Try again next time; [/]"
                );
                break;
            }
            if (sb.ToString() == randomKey.ToString())
            {
                winGame = true;
            }
            if (winGame || correctPrediction)
            {
                Console.WriteLine("You predicted the word correctly");
                AnsiConsole.MarkupLine(Emoji.Known.Trophy + " You won the game");
                break;
            }
            AnsiConsole.Markup(
                Emoji.Known.LightBulb
                    + "[yellow italic]Just guess a letter[/] [red bold]OR[/] "
                    + Emoji.Known.CheckMark
                    + "[yellow italic]Just guess the whole word[/]"
            );
            Console.WriteLine("");
            AnsiConsole.MarkupLine("[red bold]Hint: [/]" + $"[yellow bold]{words[randomKey]}[/]");
            AnsiConsole.Markup("[red bold]Available Lives[/]:   ");
            for (int i = 0; i < lives; i++)
            {
                AnsiConsole.Write(Emoji.Known.RedHeart + " ");
            }
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Your progress: " + sb.ToString());
            string? input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("The input cannot be empty");
                reduceLives();
            }
            else
            {
                if (!checkInput(input))
                {
                    reduceLives();
                }
            }
        }
    }
}
