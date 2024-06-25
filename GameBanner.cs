using Spectre.Console;

public class GameBanner
{
    public GameBanner(string Title, string Description)
    {
        AnsiConsole.Write(new FigletText(Title).LeftJustified().Color(Color.Red));
        AnsiConsole.Write(new Rule(Description).RuleStyle(Color.Red));
    }
}
