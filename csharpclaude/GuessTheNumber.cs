public static class GuessTheNumber
{
    public static void Play()
    {
        // Set up the game
        int secretNumber = Random.Shared.Next(1, 101);
        int attempts = 0;
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        while (true)
        {
            // Ask the player to guess
            Console.Write("Enter your guess: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }
            attempts++;

            // Check the guess and give feedback
            if (guess < secretNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                break;
            }
        }

        // Announce the result
        Console.WriteLine($"Correct! The number was {secretNumber}. You got it in {attempts} attempts.");
    }
}
