using DevTeamMgmtApp.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmt.app
{
    class ProgramUI
    {
        private object newDeveloper;

        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //options
                Console.WriteLine("Select a menu option:\n" +
                    " 1.  Create a Developer\n" +
                    " 2.  Browse a list of Developers\n" +
                    " 3.  Search for developer by ID\n" +
                    " 4.  Update a Developer\n" +
                    " 5.  Remove a Developer\n" +
                    "11.  Create a DevTeam\n" +
                    "12.  Browse a list of DevTeams\n" +
                    "13.  Browse a single DevTeam\n" +
                    "14.  Update a DevTeam\n" +
                    "15.  Delete a DevTeam\n" +
                    "00.  Exit");

                //selection
                Console.ReadLine();
                string selection = Console.ReadLine();

                //evaulate and act
                switch (selection)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        BrowseDeveloperList();
                        break;
                    case "3":
                        SearchDeveloperByID();
                        break;
                    case "4":
                        UpdateDeveloper();
                        break;
                    case "5":
                        RemoveDeveloper();
                        break;
                    case "11":
                        CreateDevTeam();
                        break;
                    case "12":
                        BrowseDevTeamList();
                        break;
                    case "13":
                        BrowseSingleDevTeam();
                        break;
                    case "14":
                        UpdateDevTeam();
                        break;
                    case "15":
                        RemoveDevTeam();
                        break;
                    case "00":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;

                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new DevTeam
        private void CreateDeveloper()
        {
            DevTeam newDevTeam = new DevTeam();

            //TeamName
            Console.WriteLine("Create a team name:");
            newDevTeam.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Create the team id:");
            newDevTeam.TeamId = Console.ReadLine();

            //List of Developers on team
            Console.WriteLine("List team members:");
            newDevTeam.Developers = Console.ReadLine();

            //Developer Access to Pluralsight?
            Console.WriteLine("Does team member have access to Pluralsight?");
            bool accessToPluralSight = Console.ReadLine();

            if (accessToPluralSight == "yes")
            {
                accessToPluralSight = true;
            }
            else
            {
                accessToPluralSight = false;
            }
        }
        //Read or display all Developers
        private void BrowseDeveloperList()
        {
            List<DeveloperPoco> listOfDevelopers = GetDevelopersList();
        }
        //Read or display all DevTeams
        private void SearchDeveloperByID()
        {
            List<DevTeamPoco> listOfDevTeams = GetDevTeamsList();
        }
        //Update or edit a Devteam
        private void UpdateDeveloper()
        {

        }
        private void RemoveDeveloper()
        {

        }
        private void CreateDevTeam()
        {

        }
        private void BrowseDevTeamList()
        {

        }
        private void BrowseSingleDevTeam()
        {

        }
        private void UpdateDevTeam()
        {

        }
        private void RemoveDevTeam()
        {

        }
        //Delete or remove Developers from DevTeam
        private void
    }
}

