using CafeMenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu
{
    class ProgramUI
    {
        private CafeMenuRepo _cafeMenuRepo = new CafeMenuRepo();
        public void Run()
        {
            SeedData();
            CafeMenu();
        }
        public void CafeMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\tKomodo Cafe\n\n" +

                    "\t\t\t1. Welcome to Cafe Komodo! Press 1 to make make and view changes.\n" +
                    "\t\t\t2. Exit \n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Welcome();
                        //Options
                        break;
                    case "2":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid entry.");
                        break;
                }
            }
        }
        private void Welcome()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu Options\n\n" +
                    "1. Add to Menu \n" +
                    "2. Read List of Menu \n" +
                    "3. Delete List of Menu \n" +
                    "4. Return to Main Menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddCafeContent();
                        //Add to Menu
                        break;

                    case "2":
                        ReadCafeContent();
                        //Delete
                        break;

                    case "3":
                        DeleteCafeContent();
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter valid entry.");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddCafeContent()
        {
            Console.Clear();
            CafeContent cafeContent = new CafeContent();

            //Order Number
            Console.WriteLine("Add order number");
            string orderNumberAsString = Console.ReadLine();
            cafeContent.OrderNumber = int.Parse(orderNumberAsString);

            //Price
            Console.WriteLine("Enter Price for new Menu Item");
            string priceAsString = Console.ReadLine();
            cafeContent.Price = int.Parse(priceAsString);

            //Menu
            Console.WriteLine("Enter new item for Menu");
            cafeContent.Menu = Console.ReadLine();

            //Description
            Console.WriteLine("Enter Description");
            cafeContent.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("Enter Ingredients");
            cafeContent.Ingredients = Console.ReadLine();

            _cafeMenuRepo.CreateNewMenuContent(cafeContent);
        }
        private void ReadCafeContent()
        {
            Console.Clear();
            List<CafeContent> listOfCafeContent = _cafeMenuRepo.GetCafeContents();

            foreach (CafeContent cafeContent in listOfCafeContent)
            {
                Console.WriteLine($"${cafeContent.Price}\t {cafeContent.OrderNumber}. {cafeContent.Menu}:{cafeContent.Description}.. \n \t\t{cafeContent.Ingredients} \n\n");
            }
        }
        public void DeleteCafeContent()
        {
            Console.Clear();
            //Get content to delete
            ReadCafeContent();
            Console.WriteLine("Enter content to remove:");

            string input = Console.ReadLine();
            //Call delete method
            bool wasDeleted = _cafeMenuRepo.DeleteCafeContent(input);
            if (wasDeleted)
            {
                Console.WriteLine("Successfully deleted.");
            }
            else
            {
                Console.WriteLine("Unable to delete.");
            }
        }
        //Helper
        private void ViewContent(CafeContent cafeContent)
        {
            Console.WriteLine(
                $"Order Number: {cafeContent.OrderNumber}\n" +
                $"Menu: {cafeContent.Menu}\n" +
                $"Description: {cafeContent.Description}\n" +
                $"Ingredients: {cafeContent.Ingredients}\n" +
                $"Price: {cafeContent.Price}");
        }
        private void SeedData()
        {
            CafeContent chickenparm = new CafeContent(1, "Chicken Parmesan", "Perfectly baked crusted chicken, smothered in our home - made robust tomato sauce.Served on top of our home - made fettuccine noodles.", "-Ingredients:Chicken breast, parmesan cheese, tomatoes, salt, pepper, flour, baking powder", 16.99);
            CafeContent filetscallops = new CafeContent(2, "Filet and Scallops", "Filet mignon, salt aged for 45 days, served along side our fresh, seared to perfection scallops.", "-Ingredients:Beef, scallops, salt, pepper, olive oil", 30.00);
            CafeContent stuffedpepps = new CafeContent(3, "Stuffed Peppers", "Fresh garden peppers, filled with your choice of vegatables, rice, 4 different cheeses and our locally raised beef.", "-Ingredients:Green Pepper, beans, corn, rice, cheese, beef", 22.50);
            CafeContent chickenshrimp = new CafeContent(4, "Chicken and Shrimp Alfredo", "Juicy chicken bites tossed with shrimp, on top of our home-made fettuccine noodles and our creamy alfredo sauce.", "-Ingredients: Chicken, shrimp, milk, parmesan cheese, heavy cream, flour, baking powder", 28.00);
            CafeContent fruitsalad = new CafeContent(5, "Fruit Salad", "Garden fresh fruits tossed and topped with our strawberry yogurt", "-Ingredients: Bananas, strawberries, grapes, kiwi, watermellon, strawberry yogurt", 15.00);

            _cafeMenuRepo.CreateNewMenuContent(chickenparm);
            _cafeMenuRepo.CreateNewMenuContent(filetscallops);
            _cafeMenuRepo.CreateNewMenuContent(stuffedpepps);
            _cafeMenuRepo.CreateNewMenuContent(chickenshrimp);
            _cafeMenuRepo.CreateNewMenuContent(fruitsalad);
        }
    }
}

