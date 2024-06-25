using Spectre.Console;

public class Prompt
{
    public List<String> games;

    public Prompt()
    {
        this.games = new List<string>();
    }

    public string ExecPromptSelection()
    {
        var filePath = "./Games.lst";
        if (File.Exists(filePath))
        {
            // Open the file and create a StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;

                // Read and display lines from the file until the end
                while ((line = reader.ReadLine()) != null)
                {
                    this.games.Add(line);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        // Ask for the user's favorite fruit
        for (int i = 0; i < this.games.Count(); i++)
        {
            if (String.IsNullOrEmpty(this.games[i]))
            {
                this.games.RemoveAt(i);
            }
        }
        AnsiConsole.MarkupLine(
            "[red]Info:[/] [blue bold]Move up and down to select the available options[/]"
        );
        AnsiConsole.WriteLine();
        string game = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green bold]Select the available games[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(games)
        );
        return game;
    }
}
