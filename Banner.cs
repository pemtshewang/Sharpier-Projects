using Spectre.Console;

public class Banner
{
    public void printBanner()
    {
        var rule1 = new Rule("[yellow bold]Brought to you by[/][cyan bold] Pem Tshewang [/]");
        AnsiConsole.Write(rule1.Centered());
        var rule = new Rule($"[green]{DateTime.Now}[/]");
        AnsiConsole.Write(new FigletText("Sharpier Games").Centered().Color(Color.Navy));
        AnsiConsole.Write(rule.Centered());
    }
}
