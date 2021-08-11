using JibbleConsoleClient.Models;
using JibbleConsoleClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JibbleConsoleClient
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            IPeopleService peopleService = new PeopleService();
            await MenuAsync(peopleService);
        }

        static async Task MenuAsync(IPeopleService peopleService)
        {
            Console.Clear();
            Console.WriteLine("Please select 1,2,3 or 4 to proceed");
            Console.WriteLine("");
            Console.WriteLine("Option 1. List people");
            Console.WriteLine("Option 2. Search/filter people");
            Console.WriteLine("Option 3. Load person details");
            Console.WriteLine("Option 4. Exit");
            Console.WriteLine();

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await LoadPeopleAsync(peopleService);
                    break;
                case "2":
                    await SearchPeople(peopleService);
                    break;
                case "3":
                    await LoadPersonDetails(peopleService);
                    break;
                case "4":
                    Exit();
                    break;
                default:
                    break;
            }

           await MenuAsync(peopleService);
        }

        private static async Task LoadPersonDetails(IPeopleService peopleService)
        {
            //Show details on a specific Person
            Console.WriteLine("Enter username");
            var username = Console.ReadLine();
            Console.WriteLine("Loading...");
            var personDetails = await peopleService.PersonDetails(username);
            if (personDetails != null)
            {
                Console.WriteLine($"UserName | FirstName | LastName  | Address |  City");
                Console.WriteLine("***************************************************");
                Console.WriteLine($"{personDetails.UserName} | {personDetails.FirstName} | {personDetails.LastName}  |  {personDetails.AddressInfo.FirstOrDefault()?.Address}  | {personDetails.AddressInfo.FirstOrDefault()?.City?.Name}");               
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Record not found");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        private static async Task SearchPeople(IPeopleService peopleService)
        {
            //Allow searching/filtering people
            Console.WriteLine("Enter keyword to search");
            var keyword = Console.ReadLine();
            Console.WriteLine("Searching...");
            var searchResults = await peopleService.SearchPeople(keyword);
            Console.WriteLine($"UserName | FirstName | LastName  | Gender  |  Age");
            Console.WriteLine("**************************************************");
            foreach (var person in searchResults)
            {
                Console.WriteLine($"{person.UserName} | {person.FirstName} | {person.LastName}  | {person.Gender}  | {person?.Age??"Not set"}");
            }           
            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        private static void Exit()
        {
            Console.WriteLine("Press Enter key to exit");
            Console.ReadLine();
            Environment.Exit(1);
        }
       
        private static async Task LoadPeopleAsync(IPeopleService peopleService)
        {
            //List people
            Console.WriteLine("Loading.....");
            var people = await peopleService.ListPeople();
            Console.WriteLine($"            List of people                 ");
            Console.WriteLine();
            Console.WriteLine($" UserName  |  FirstName  |  LastName  |  Gender");
            Console.WriteLine("*************************************************");
            foreach (var person in people)
            {
                Console.WriteLine($" {person.UserName}  |  {person.FirstName}  |  {person.LastName}  |  {person.Gender??""}");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
           
        }
    }
}
