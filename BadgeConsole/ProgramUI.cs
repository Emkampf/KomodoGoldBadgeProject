using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    class ProgramUI
    {
        readonly BadgeRepo _badgeRepo = new BadgeRepo();
        private Dictionary<string, List<string>> _badgeContent = new Dictionary<string, List<string>>();
        public void Run()
        {
            SeedData();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadge();
                        break;
                    case "4":
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid entry.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            BadgeContent badgeContent = new BadgeContent();
            BadgeRepo badgeNumber = new BadgeRepo();

            Console.Clear();
            Console.WriteLine("What is the number on the badge:");
            badgeContent.BadgeId = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("List a door that it needs access to:");
            List<string> doorAccess = new List<string> { Console.ReadLine() };
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Any other doors(y/n)?");
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                if (userInput == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
                }
                else
                    isRunning = false;
                Console.Clear();
                Console.WriteLine("Any other doors(y/n)?");
                userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
                }
                else
                    isRunning = false;
            }
            _badgeContent.Add(badgeId, doorAccess);
            BadgeContent content = new BadgeContent(badgeNumber, doorAccess);
            badgeContent.Add(badgeContent);

            Console.WriteLine("Return to main menu");
                Console.ReadKey();
                Console.Clear();
        }
        private void EditBadge()
        {
            Console.WriteLine("What is the badge number to update?");

            //must return badge id and access numbers
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove a door\n" +
                    "2. Add a door");
             
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Which door would you like to remove?");
                        string dev1 = Console.ReadLine();
                        _badgeContent.Remove(dev1);
                        Console.WriteLine("Door removed.");
                        break;
                    case "2":
                        Console.WriteLine("Add a door:");
                        string user2 = Console.ReadLine();
                        _badgeContent.Add(user2);
                        Console.WriteLine("Door added.");
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2 for valid entry");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ListBadge()
        {
            Console.Clear();
            Console.WriteLine("Key");
            Console.WriteLine("Badge #");
            Console.WriteLine("BadgeID#\tDoor Access");
            foreach (var id in _badgeContent)
            {
                Console.WriteLine($"Id{id.Key}");
                foreach(var door in id.Value)
                    Console.WriteLine($"\t\t{door}");
            }
            Console.WriteLine("\n");
        }

        private void SeedData()
        {
            BadgeContent badgeOne = new BadgeContent("12345", new List<string>() {"A7"});
            BadgeContent badgeTwo = new BadgeContent("22345", new List<string>() { "A1", "A4", "B1", "B2" });
            BadgeContent badgeThree = new BadgeContent("32345", new List<string>() { "A4", "A5" });

            _badgeRepo.AddContent(badgeOne);
            _badgeRepo.AddContent(badgeTwo);
            _badgeRepo.AddContent(badgeThree);

            _badgeContent.Add(badgeOne.BadgeId, badgeOne.DoorNames);
            _badgeContent.Add(badgeTwo.BadgeId, badgeTwo.DoorNames);
            _badgeContent.Add(badgeThree.BadgeId, badgeThree.DoorNames);
        }
    }
}
