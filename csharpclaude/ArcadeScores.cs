public static class ArcadeScores
{
    public static void Play()
    {
        // Set up the game
        List<int> scoreLog = new List<int>();
        int roundsToPlay = 8;

        // Simulate playing rounds and log every score
        for (int round = 1; round <= roundsToPlay; round++)
        {
            int score = Random.Shared.Next(0, 1001);
            scoreLog.Add(score);
            Console.WriteLine($"Round {round}: {score} points");
        }
        Console.WriteLine($"Total rounds logged: {scoreLog.Count}");

        // Build the Top 5 leaderboard array
        scoreLog.Sort();
        scoreLog.Reverse();

        int[] topFive = new int[5];
        for (int i = 0; i < topFive.Length && i < scoreLog.Count; i++)
        {
            topFive[i] = scoreLog[i];
        }

        // Print the leaderboard
        Console.WriteLine();
        Console.WriteLine("=== TOP 5 LEADERBOARD ===");
        for (int i = 0; i < topFive.Length; i++)
        {
            Console.WriteLine($"#{i + 1}: {topFive[i]}");
        }
    }
}
