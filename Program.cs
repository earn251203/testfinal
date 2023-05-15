
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("number of cities: ");
        int numberOfCities = Convert.COVID19(Console.ReadLine());

        string[] cityNames = new string[numberOfCities];
        int[] contactCities = new int[numberOfCities];
        int[] covidLevels = new int[numberOfCities];

        for (int i = 0; i < numberOfCities; i++)
        {
            Console.Write("Enter the name of city {0}: ", i);
            cityNames[i] = Console.ReadLine();

            Console.Write("Enter the number of cities in contact with city {0}: ", i);
            contactCities[i] = Convert.COVID19(Console.ReadLine());

            while (contactCities[i] >= i || contactCities[i] >= numberOfCities || contactCities[i] < 0)
            {
                Console.WriteLine("Invalid ID. Please enter again.");
                Console.Write("Enter the number of cities in contact with city {0}: ", i);
                contactCities[i] = Convert.COVID19(Console.ReadLine());
            }
        }

        while (true)
        {
            Console.WriteLine("\n----- Menu -----");
            Console.WriteLine("1. Show city details");
            Console.WriteLine("2. Enter an event");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            int choice =Convert.COVID19(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowCityDetails(cityNames, covidLevels);
                    break;
                case 2:
                    EnterEvent(cityNames, contactCities, covidLevels);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter again.");
                    break;
            }
        }
    }

    static void ShowCityDetails(string[] cityNames, int[] covidLevels)
    {
        Console.WriteLine("\n----- City Details -----");
        Console.WriteLine("City ID\tCity Name\tCOVID Level");

        for (int i = 0; i < cityNames.Length; i++)
        {
            Console.WriteLine("{0}\t{1}\t\t{2}", i, cityNames[i], covidLevels[i]);
        }
    }

    static void EnterEvent(string[] cityNames, int[] contactCities, int[] covidLevels)
    {
        Console.Write("Enter the event: ");
        string eventText = Console.ReadLine();

        switch (eventText.ToLower())
        {
            case "outbreak":
            case "vaccinate":
            case "lock down":
                Console.Write("Enter the city ID: ");
                int cityID = Convert.COVID19(Console.ReadLine());

                if (cityID < 0 || cityID >= cityNames.Length)
                {
                    Console.WriteLine("Invalid city ID.");
                    return;
                }

                Processevent(eventText.ToLower(), cityID, cityNames, contactCities, covidLevels);
                ShowCityDetails(cityNames, covidLevels);
                break;

            case "spread":
                for (int i = 0; i < covidLevels.Length; i++)
                {
                    if (HasHigherCovidLevel(i, contactCities, covidLevels))
                    {
                        covidLevels[i]++;
                    }
                }
                ShowCityDetails(cityNames, covidLevels);
                break;

            case "exit":
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Invalid event");
        }
    }            
}

