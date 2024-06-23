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
    sb.Append("+");
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
        Console.WriteLine("You Lost :x Tryagain next time;");
        break;
    }
    if (sb.ToString() == randomKey.ToString())
    {
        winGame = true;
    }
    if (winGame || correctPrediction)
    {
        Console.WriteLine("Correct Prediction of the word: " + randomKey);
        Console.WriteLine("You won the game");
        break;
    }
    Console.WriteLine("Fill the letters by Guessing the programming language! :)");
    Console.WriteLine("");
    Console.WriteLine("Hint: " + words[randomKey]);
    for (int i = 0; i < lives; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine("Guess a letter or word");
    Console.WriteLine("Your progress: " + sb.ToString());
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
