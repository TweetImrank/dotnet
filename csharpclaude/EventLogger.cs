public static class EventLogger
{
    public static void Run()
    {
        string logPath = "events.log";

        // Log a new event
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Program started{Environment.NewLine}";
        File.AppendAllText(logPath, entry);

        // Read back every logged event
        int eventCount = 0;
        Console.WriteLine("===== EVENT HISTORY =====");
        using (StreamReader reader = new StreamReader(logPath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                eventCount++;
            }
        }

        // Count the logged events
        Console.WriteLine("=========================");
        Console.WriteLine($"Total events logged: {eventCount}");
    }
}
