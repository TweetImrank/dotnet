public static class OurAnimals
{
    public static void Run()
    {
        // the ourAnimals array will store the following:
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";

        // variables that support data entry
        int maxPets = 8;
        string? readResult;
        string menuSelection = "";

        // array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 6];

        // create some initial ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "loki";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "Puss";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "?";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;
            }

            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
        }

        // display the top-level menu options until the user enters "exit"
        do
        {
            // Console.Clear throws when output is redirected
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal’s age");
            Console.WriteLine(" 6. Edit an animal’s personality description");
            Console.WriteLine(" 7. Display all cats with a specified characteristic");
            Console.WriteLine(" 8. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();

            // treat end of input as exit so the loop can't spin forever
            menuSelection = readResult == null ? "exit" : readResult.Trim().ToLower();

            switch (menuSelection)
            {
                case "1":
                    // List all of our current pet information
                    for (int i = 0; i < maxPets; i++)
                    {
                        // skip empty slots - an unused pet has only the "ID #: " label
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 6; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }
                    break;

                case "2":
                    // Add a new animal friend to the ourAnimals array
                    string anotherPet = "y";
                    int petCount = 0;

                    // count the pets that have data assigned
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            petCount += 1;
                        }
                    }

                    if (petCount < maxPets)
                    {
                        Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
                    }

                    // enter new ourAnimals array data
                    while (anotherPet == "y" && petCount < maxPets)
                    {
                        bool validEntry;

                        // get species (cat or dog) - required
                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            animalSpecies = ReadInput().ToLower();
                            validEntry = animalSpecies == "dog" || animalSpecies == "cat";
                        } while (!validEntry);

                        // build the animal ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        // get the pet's age - a whole number, or ? if unknown
                        do
                        {
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            animalAge = ReadInput();
                            validEntry = animalAge == "?" || int.TryParse(animalAge, out _);
                        } while (!validEntry);

                        // get a description of the pet's physical appearance - can be left blank
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            animalPhysicalDescription = ReadInput().ToLower();
                            if (animalPhysicalDescription == "")
                            {
                                animalPhysicalDescription = "tbd";
                            }
                        } while (animalPhysicalDescription == "");

                        // get a description of the pet's personality - can be left blank
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            animalPersonalityDescription = ReadInput().ToLower();
                            if (animalPersonalityDescription == "")
                            {
                                animalPersonalityDescription = "tbd";
                            }
                        } while (animalPersonalityDescription == "");

                        // get the pet's nickname - can be left blank
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            animalNickname = ReadInput();
                            if (animalNickname == "")
                            {
                                animalNickname = "tbd";
                            }
                        } while (animalNickname == "");

                        // store the pet information in the ourAnimals array (zero based)
                        ourAnimals[petCount, 0] = "ID #: " + animalID;
                        ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                        ourAnimals[petCount, 2] = "Age: " + animalAge;
                        ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                        ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                        ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                        // the array is zero-based, so increment the counter after adding to the array
                        petCount += 1;

                        // only offer another pet if there is room left
                        if (petCount < maxPets)
                        {
                            Console.WriteLine("Do you want to enter info for another pet (y/n)");
                            do
                            {
                                readResult = Console.ReadLine();
                                // treat end of input as "n" so this loop can't spin forever
                                anotherPet = readResult == null ? "n" : readResult.Trim().ToLower();
                            } while (anotherPet != "y" && anotherPet != "n");
                        }
                    }

                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                    }
                    break;

                case "3":
                    // Ensure animal ages and physical descriptions are complete
                    for (int i = 0; i < maxPets; i++)
                    {
                        // skip empty slots - an unused pet has only the "ID #: " label
                        if (ourAnimals[i, 0] == "ID #: ")
                        {
                            continue;
                        }

                        string petID = ourAnimals[i, 0].Substring(6);

                        // age must convert to a number
                        animalAge = ourAnimals[i, 2].Substring(5);
                        while (!int.TryParse(animalAge, out _))
                        {
                            Console.WriteLine($"Enter an age for ID #: {petID}");
                            animalAge = ReadInput();
                        }
                        ourAnimals[i, 2] = "Age: " + animalAge;

                        // physical description can't be empty (or the "tbd" placeholder)
                        animalPhysicalDescription = ourAnimals[i, 4].Substring(22);
                        while (string.IsNullOrEmpty(animalPhysicalDescription) || animalPhysicalDescription == "tbd")
                        {
                            Console.WriteLine($"Enter a physical description for ID #: {petID} (size, color, gender, weight, housebroken)");
                            animalPhysicalDescription = ReadInput().ToLower();
                        }
                        ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                    }

                    Console.WriteLine("\nAge and physical description fields are complete for all of our friends.");
                    break;

                case "4":
                    // Ensure animal nicknames and personality descriptions are complete
                    Console.WriteLine("Challenge Project - please check back soon to see progress.");
                    break;

                case "5":
                    // Edit an animal's age
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    break;

                case "6":
                    // Edit an animal's personality description
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    break;

                case "7":
                    // Display all cats with a specified characteristic
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    break;

                case "8":
                    // Display all dogs with a specified characteristic
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    break;

                case "exit":
                    continue;

                default:
                    Console.WriteLine($"\"{menuSelection}\" is not a valid selection.");
                    break;
            }

            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            if (readResult == null)
            {
                menuSelection = "exit";
            }

        } while (menuSelection != "exit");
    }

    // reads a trimmed line; ends the program if input runs out so validation loops can't spin forever
    static string ReadInput()
    {
        string? readResult = Console.ReadLine();
        if (readResult == null)
        {
            Environment.Exit(0);
        }
        return readResult.Trim();
    }
}
