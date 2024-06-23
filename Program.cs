using System.Text;

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
int randIndex = new Random().Next(1, words.Count());
List<string> keys = words.Keys.ToList();
string randomKey = keys[randIndex];

void reduceLives()
{
    lives--;
    Console.WriteLine("Your Life is getting reduced");
}

StringBuilder sb = new StringBuilder("", randIndex);
for (int i = 0; i < randomKey.Length; i++)
{
    sb.Append("+");
}

while (!winGame)
{
    Console.WriteLine("Fill the letters by Guessing the programming language! :)");
    Console.WriteLine("");
    Console.WriteLine("Hint: " + words[randomKey]);
    for (int i = 0; i < lives; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine("Guess a letter or word");
    Console.WriteLine("Your progress: " + sb.ToString());
    string input = Console.ReadLine();
    if (String.IsNullOrEmpty(input))
    {
        Console.WriteLine("The input cannot be empty");
    }
}
