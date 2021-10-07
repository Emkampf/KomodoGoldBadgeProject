using Claims_Department_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Claims_Department_Repository.ClaimsContent;

namespace ClaimsDepartment
{
    class ProgramUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            SeedData();
            MainMenu();
        }
        private void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Komodo Claims Department\n\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddClaimContent();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //CREATE
        private void AddClaimContent()
        {
            Console.Clear();
            ClaimsContent newClaimsContent = new ClaimsContent();
            //ClaimId

            Console.WriteLine("Enter claim id:");
            string claimIdAsString = Console.ReadLine();
            newClaimsContent.ClaimId = int.Parse(claimIdAsString);

            //ClaimType
            Console.WriteLine("Enter claim type(1=Car, 2=Home, 3=Theft:");
            string typeOfClaimAsString = Console.ReadLine();
            newClaimsContent.TypeOfClaim = (ClaimType)int.Parse(typeOfClaimAsString);

            //Description
            Console.WriteLine("Enter claim description:");
            newClaimsContent.Description = Console.ReadLine();

            //Amount
            Console.WriteLine("Amount of Damage:");
            string amountAsString = Console.ReadLine();
            newClaimsContent.ClaimAmount = decimal.Parse(amountAsString);

            //DateOfAccident
            Console.WriteLine("Enter date of Accident as 00/00/00:");
            DateTime inputIncidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of Claim as 00/00/00:");
            DateTime inputClaimDate = DateTime.Parse(Console.ReadLine());

            _repo.AddClaimContent(newClaimsContent);
            Console.ReadKey();
        }
        //READ
        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<ClaimsContent> queueClaimsContents = _repo.GetClaimsContents();

            Console.WriteLine($"ClaimID\tType\t Amount\t\tDescription\t\t\t\t\tDateOfIncident\tDateOfClaim        IsValid");
            foreach (ClaimsContent claimsContent in queueClaimsContents)
            {
                Console.WriteLine($"{claimsContent.ClaimId}\t {claimsContent.TypeOfClaim}\t  ${claimsContent.ClaimAmount} \t {claimsContent.Description}\t {claimsContent.DateOfIncident:d} \t{claimsContent.DateOfClaim:d} \t {claimsContent.IsValid}");
            }
            Console.ReadKey();
        }


        public void NextClaim()
        {
            Console.Clear();
            Queue<string> claimsContent = new Queue<string>();     //How to pull first up in queue- must make seed data queue
            claimsContent.Enqueue("ClaimId: 1");
            claimsContent.Enqueue("Type: Car");
            claimsContent.Enqueue("Description: Turned into transformer, took out a bridge.");
            claimsContent.Enqueue("Amount: $1000.50");
            claimsContent.Enqueue("DateOfAccident: 09/25/21");
            claimsContent.Enqueue("DateOfClaim: 09/28/21");
            claimsContent.Enqueue("IsValid: True");

            foreach (string ClaimsContent in claimsContent)
            {
                Console.WriteLine(ClaimsContent);
            }

            //IsValid
            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string isValidAsString = Console.ReadLine().ToLower();
            Console.Clear();
            if (isValidAsString == "y")
            {
                Console.WriteLine("Item in Queue: {0}", claimsContent.Peek()); //Move? I want this to jump to Enter Claim Id for Update
            }
            else
            {
                MainMenu();
            }
            Console.ReadKey();
        }
        private void SeedData()
        {
            ClaimsContent carClaim = new ClaimsContent(1, ClaimType.Car, "Turned into transformer, took out a bridge.", 1000.50m, new DateTime(2021, 09, 25), new DateTime(2021, 09, 28), true);
            ClaimsContent homeClaim = new ClaimsContent(2, ClaimType.Home, "Sinkhole opened up and swallowed kitchen.", 1500.00m, new DateTime(2021, 01, 25), new DateTime(2021, 08, 18), true);
            ClaimsContent theftClaim = new ClaimsContent(3, ClaimType.Theft, "Stole a car and drove it through a wig store.", 500.00m, new DateTime(2021, 09, 15), new DateTime(2021, 10, 02), false);

            _repo.AddClaimContent(carClaim);
            _repo.AddClaimContent(homeClaim);
            _repo.AddClaimContent(theftClaim);
        }
    }
}
