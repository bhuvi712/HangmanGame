

using System.Xml.Linq;

internal class Program
{
    static string Name;
    static int NumberOfGuesses;
    static string correctword = "hangman";
    static char[] letters;

    private static void Main(string[] args)
    {
        StartGame();
        PlayGame();
        EndGame();
        Console.WriteLine("Test");
    }

    private static void StartGame()
    {
        letters = new char[correctword.Length];           
        for (int i = 0; i < correctword.Length; i++)
        {
            letters[i] = '-';
            
        }
        AskforUserName();
    }
    static void AskforUserName()
    { 
        Console.WriteLine("Enter your name:");
        string input = Console.ReadLine();
        if (input.Length >= 2)
            Name = input;
        else
        {
            // The user entered an invalid name
            AskforUserName();
        }
    }
    private static void PlayGame()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Playing the game...");
            DisplayMaskedWord();
            char guessesLetter = AskForLetter();
            CheckLetter(guessesLetter);
        } while (correctword != new string(letters));
    Console.Clear();

    }

    private static void CheckLetter(char guessesLetter)
    {
        for (int i = 0; i < correctword.Length; i++)
        {
            if (guessesLetter == correctword[i])
                letters[i] = guessesLetter;
        }
    }

    static void DisplayMaskedWord()
    {
        foreach(char c in letters)
        {
            Console.WriteLine(c);
            Console.WriteLine();
        }
    }
    static char AskForLetter()
    {
        string input;
        do
        {
            Console.WriteLine("Enter a Letter:");
            input = Console.ReadLine();
        }while(input.Length != 1);

        NumberOfGuesses++;
        return input[0];
    }

    private static void EndGame()
    {
        Console.WriteLine("Game over...");
        Console.WriteLine($"Thank you for playing: {Name}");
        Console.WriteLine($"Guesses: {NumberOfGuesses}");


    }
}