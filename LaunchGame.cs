using Projects;
using Spectre.Console;

public class LaunchGame
{
    public LaunchGame(string SelectedGame)
    {
        switch (SelectedGame)
        {
            case "Guessing Game":
                AnsiConsole.Clear();
                new GameBanner("Guessing Game", "Just Guess the Programming Language");
                new GuessingGame().Play();
                break;
        }
    }
}
