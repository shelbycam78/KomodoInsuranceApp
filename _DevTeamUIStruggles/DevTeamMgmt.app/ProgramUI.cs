using DevTeamMgmtApp.poco;
using DevTeamMgmtApp.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DevTeamMgmt.app
{
    public class ProgramUI
    {
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedDevelopers();
            Menu();
        }
        private void Menu()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {

                Console.WriteLine("Komodo Management - Please select a menu option:\n" +
                    "***********************************\n" +
                    " 1.  Create a Developer\n" +
                    " 2.  Browse a list of Developers\n" +
                    " 3.  Search for a Developer by ID\n" +
                    " 4.  Update a Developer\n" +
                    " 5.  Remove a Developer\n" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                    "11.  Create a DevTeam\n" +
                    "12.  Browse a list of DevTeams\n" +
                    "13.  Browse a single DevTeam\n" +
                    "14.  Update a DevTeam\n" +
                    "15.  Delete a DevTeam\n" +
                    "00.  Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByID();
                        break;
                    case "4":
                        UpdateDeveloper();
                        break;
                    case "5":
                        DeleteDeveloper();
                        break;
                    case "11":
                        CreateTeam();
                        break;
                    case "12":
                        ViewAllTeams();
                        break;
                    case "13":
                        ViewSingleTeam();
                        break;
                    case "14":
                        UpdateTeam();
                        break;
                    case "15":
                        DeleteTeam();
                        break;
                    case "00":
                        isRunning = false;
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

        private void AddDeveloper()
        {
            Console.Clear();
            var developer = new Developer();
            var team = new DevTeam();

            AskAQuestion("Please input Dev FirstName:");
            string userInputFirstName = Console.ReadLine();
            developer.FirstName = userInputFirstName;

            AskAQuestion("Please input Dev LastName:");
            var userInputLastName = Console.ReadLine();
            developer.LastName= userInputLastName;

            AskAQuestion("Does this Dev have P.S. Access (y/n)?");
            string userInputPSAccess = Console.ReadLine();

            if (userInputPSAccess=="Y".ToLower())
            {
                developer.AccessToPluralSight = true;
            }
            else
            {
                developer.AccessToPluralSight = false;

            }


            Console.WriteLine("Please Select a DevTeam to be Assigned To:\n" +
                "1.East\n" +
                "2.West\n" +
                "3.NoTeam\n");

            
            var userInputTeamSelection = Console.ReadLine();

            switch (userInputTeamSelection)
            {
                case "1":
                    developer.DevTeam = "East";
                    break;
                case "2":
                    developer.DevTeam = "West";
                    break;
                case "3":
                    developer.DevTeam = null;
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    Menu();
                    break;
            }

            var success = _devRepo.AddDeveloper(developer);
            if (success)
            {
                team = AssignToDevTeam(developer, developer.DevTeam);
                if (team !=null)
                {
                    team.Developers.Add(developer);
                }
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("FAILURE");
            }

            Console.ReadKey();
        }

        private DevTeam AssignToDevTeam(Developer developer, string teamName)
        {
           var team = _devTeamRepo.GetDevTeamByName(developer.DevTeam);
            return team;
        }
        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _devRepo.GetDevelopers().ToList();
            //loop through the list and get the data...
            foreach (var dev in listOfDevelopers)
            {
                ViewDevData(dev);
            }

            Console.ReadKey();
        }
        //helper Method
        private void ViewDevData(Developer developer)
        {
            Console.WriteLine($"DevID: {developer.Id}\n" +
                              $"DeveloperName: {developer.FullName}\n");
            if (string.IsNullOrWhiteSpace(developer.DevTeam))
            {
                Console.WriteLine("Not assigned to a team");
            }
            else
            {
                Console.WriteLine($"{developer.DevTeam}");
            }

            Console.WriteLine($"AcceessPluralsight: {developer.AccessToPluralSight}");
            Console.WriteLine("----------------------------------------------------------------");
        }

        private void ViewDeveloperByID()
        {
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeams().ToList();
        }
        private void UpdateDeveloper()
        {

        }
        private void DeleteDeveloper()
        {

        }

        private void CreateTeam()
        {
            Console.Clear();

            List<Developer> DevsInDatabase = _devRepo.GetDevelopers().ToList();

            List<Developer> DevsToBeAddedToTeam = new List<Developer>();
            bool teamPosFilled = false;

            AskAQuestion("Please enter a Team Name:");
            var userInputTeamName = Console.ReadLine();

            while (!teamPosFilled)
            {
                AskAQuestion("Do you want to add any member? y/n");
                var userInputAnyTeamMembers = Console.ReadLine();
                if (userInputAnyTeamMembers == "Y".ToLower())
                {
                    foreach (var dev in DevsInDatabase)
                    {
                        Console.WriteLine($"{dev.Id} {dev.FirstName} {dev.LastName}");
                    }

                    AskAQuestion("Please Select a Developer by Id");
                    int userInputDevId = int.Parse(Console.ReadLine());
                    
                                        var developer = _devRepo.GetDeveloperByID(userInputDevId);

                    DevsToBeAddedToTeam.Add(developer);
                    DevsInDatabase.Remove(developer);
                }
                else
                {
                    teamPosFilled = true;
                }
            }

            DevTeam devTeam = new DevTeam(userInputTeamName, DevsToBeAddedToTeam);
            bool success = _devTeamRepo.AddTeam(devTeam);

            if (success)
            {
                Console.WriteLine($"{devTeam.TeamName} was Created.");
            }
            else
            {
                Console.WriteLine("Failure.  Try again.");
            }
            Console.ReadKey();
        }
        private void ViewAllTeams()
        {
            Console.Clear();
            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();

            foreach (var team in devTeamsInDatabase)
            {
                DisplayTeamData(team);
            }

            Console.ReadKey();
        }
        private void DisplayTeamData(DevTeam team)
        {
            Console.WriteLine($"{team.TeamId}\n" +
                                $"{team.TeamName}");

            Console.WriteLine("--------------Members------------");

            foreach (var dev in team.Developers)
            {
                Console.WriteLine($"{dev.Id}\n" +
                                  $"{dev.LastName}\n" +
                                  $"{dev.AccessToPluralSight}\n");

                Console.WriteLine("*******************************\n");
            }
        }
        private void ViewSingleTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();
            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamId} {team.TeamName}");
            }

            AskAQuestion("Please enter Team ID:");
            var userInputTeamID = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamById(userInputTeamID);

            if (devTeam is null)
            {
                Console.WriteLine("Team doesn't exist.");
            }
            else
            {
                DisplayTeamData(devTeam);
            }


            Console.ReadKey();
        }    
        private void UpdateTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();

            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamId} {team.TeamName}");
            }

            AskAQuestion("Please enter Team ID:");
            var userInputTeamID = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamById(userInputTeamID);

            if (devTeam is null)
            {
                Console.WriteLine("Team doesn't exist.");
            }
            else
            {
                List<Developer> DevsInDatabase = _devRepo.GetDevelopers().ToList();

                List<Developer> DevsToBeAddedToTeam = new List<Developer>();
                bool teamPosFilled = false;

                AskAQuestion("Please enter a Team Name:");
                var userInputTeamName = Console.ReadLine();

                while (!teamPosFilled)
                {
                    AskAQuestion("Do you want to add any member? y/n");
                    var userInputAnyTeamMembers = Console.ReadLine();
                    if (userInputAnyTeamMembers == "Y".ToLower())
                    {
                        foreach (var dev in DevsInDatabase)
                        {
                            Console.WriteLine($"{dev.Id} {dev.FirstName} {dev.LastName}");
                        }

                        AskAQuestion("Please Select a Developer by Id");
                        int userInputDevId = int.Parse(Console.ReadLine());
                        
                        var developer = _devRepo.GetDeveloperByID(userInputDevId);

                        DevsToBeAddedToTeam.Add(developer);
                        DevsInDatabase.Remove(developer);
                    }
                    else
                    {
                        teamPosFilled = true;
                    }
                }

                DevTeam newDevTeamData = new DevTeam(userInputTeamName, DevsToBeAddedToTeam);
                var success = _devTeamRepo.UpdateDevTeam(userInputTeamID, newDevTeamData);

                if (success)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Faliure!");
                }
            }
            Console.ReadKey();
        }
        private void DeleteTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();
            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamId} {team.TeamName}");
            }

            AskAQuestion("Please enter Team ID:");
            var userInputTeamID = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamById(userInputTeamID);

            if (devTeam is null)
            {
                Console.WriteLine("Team doesn't exist.");
            }
            else
            {
                var success = _devTeamRepo.DeleteDevTeam(userInputTeamID);
                if (success)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failure!");
                }
            }


            Console.ReadKey();
        }

        private void SeedDevelopers()
        {
           //call type  <-filed   =  <-assigned to field (values passed w/n constructors)
            var  developerA = new        Developer("Sammy", "Sosa","East",true);
            Developer developerB = new Developer("Mark", "McGwire",true);
            Developer developerC = new Developer("Barry", "Bonds","West", true);
            Developer developerD = new Developer("Ken", "Griffey Jr.","West", true);

            _devRepo.AddDeveloper(developerA);
            _devRepo.AddDeveloper(developerB);
            _devRepo.AddDeveloper(developerC);
            _devRepo.AddDeveloper(developerD);

           
            DevTeam teamA = new DevTeam("East", new List<Developer>() { developerA });
            DevTeam teamB = new DevTeam("West", new List<Developer>() { developerC, developerD });

            _devTeamRepo.AddTeam(teamA);
            _devTeamRepo.AddTeam(teamB);
        }

        //helper methods
        private void AskAQuestion(string msg)
        {
            Console.Clear();

            Console.WriteLine(msg);

            Console.ReadKey();
        }
        private void DisplayDeveloperDetails(Developer developer)
        {

        }
        private void GiveMeDevelopers()
        {
            List<Developer> developersToView = _devRepo.GetDevelopers().ToList();

            if (developersToView.Count == 0)
            {
                Console.WriteLine("There aren't any available existing Developers.");
            }
            else
            {

            }
        }
    }
}