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
                    "1.  Browse Developers" +
                    "2.  Browse DevTeams" +
                    "3.  Create a DevTeam" +
                    "4.  Edit a DevTeam" +
                    "5.  Exit");

                //selection
                Console.ReadLine();
                string selection = Console.ReadLine();

                //evaulate and act
                switch (selection)
                {
                    case "1":
                        DisplayDevelopers();
                        break;
                    case "2":
                        DisplayDevTeams();
                        break;
                    case "3":
                        CreateDevTeam();
                        break;
                    case "4":
                        EditDevTeam();
                        break;
                    case "5":
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
        private void CreateDevTeam()
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
        private void DisplayDevelopers()
        {
            List<DeveloperPoco> listOfDevelopers = GetDevelopersList();
        }
        //Read or display all DevTeams
        private void DisplayDevTeams()
        {
            List<DevTeamPoco> listOfDevTeams = GetDevTeamsList();
        }

        //Update or edit a Devteam
        private void EditDevTeam()
        {

        }

        //Delete or remove Developers from DevTeam
        private void 

    }
}
