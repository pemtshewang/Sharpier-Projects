public class Program
{
    public static void Main(string[] args)
    {
        new Banner().printBanner();
        String SelectedGame = new Prompt().ExecPromptSelection();
        new LaunchGame(SelectedGame);
    }
}
