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

            List<DeveloperPoco> DevsInDataBase = _devRepo.GetDevelopers().ToList();

            AskAQuestion("Please enter a First Name:");
            string developerPoco = Console.ReadLine();


            Console.ReadKey();
        }
        private void ViewAllDevelopers()
        {
            Console.Clear();

            List<DeveloperPoco> listOfDevelopers = GetDevelopersList();

            Console.ReadKey();
        }
        private void ViewDeveloperByID()
        {
            
            List<DevTeamPoco> listOfDevTeams = GetDevTeamsList();
        }
        private void UpdateDeveloper()
        {
            Console.Clear();



            Console.ReadKey();
        }
        private void DeleteDeveloper()
        {
            Console.Clear();



            Console.ReadKey();
        }

        private void CreateTeam(DeveloperPoco developerPoco)
        {
            Console.Clear();
           
            List<DeveloperPoco> DevsInDatabase = _devRepo.GetDevelopers().ToList();

            List<DeveloperPoco> DevsToBeAddedToTeam = new List<DeveloperPoco>();
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
            Console.Clear();

            Console.WriteLine($"{team.TeamID}\n" +
                                $"{team.TeamName}\n");

            Console.WriteLine("--------------Members------------");

            foreach (var dev in team.Developers)
            {
                Console.WriteLine($"{dev.ID}\n" +
                                  $"{dev.FullName}\n") +
                                  $"{dev.AccessToPluralSight}\n");

                Console.WriteLine("*******************************\n");
            }

            Console.ReadKey();
        }
        private void ViewSingleTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devRepo.GetDevTeams().ToList();
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
                List<DeveloperPoco> DevsInDatabase = _devRepo.GetDevelopers().ToList();

                List<DeveloperPoco> DevsToBeAddedToTeam = new List<DeveloperPoco>();
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
                        
                        var developer = _devRepo.GetDeveloperById(userInputDevId);

                        DevsToBeAddedToTeam.Add(developerPoco);
                        DevsInDatabase.Remove(developerPoco);
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

            List<DevTeam> devTeamsInDatabase = _devRepo.GetDevTeams().ToList();
            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamId} {team.TeamName}");
            }

            AskAQuestion("Please enter Team ID:")
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
            Console.Clear();

            DeveloperPoco developerA = new DeveloperPoco("Sammy", "Sosa", true);
            DeveloperPoco developerB = new DeveloperPoco("Mark", "McGwire", true);
            DeveloperPoco developerC = new DeveloperPoco("Barry", "Bonds", true);
            DeveloperPoco developerD = new DeveloperPoco("Ken", "Griffey Jr.", true);

            _devRepo.AddDeveloperToRepo(developerA);
            _devRepo.AddDeveloperToRepo(developerB);
            _devRepo.AddDeveloperToRepo(developerC);
            _devRepo.AddDeveloperToRepo(developerD);

           
            DevTeam teamA = new DevTeam("East", new List<DeveloperPoco>() { developerA, developerB });
            DevTeam teamB = new DevTeam("West", new List<DeveloperPoco>() { developerC, developerD });

            _devTeamRepo.AddTeam(teamA);
            _devTeamRepo.AddTeam(teamB);

            Console.ReadKey();
        }

        //helper methods
        private void AskAQuestion(string v)
        {
            Console.Clear();



            Console.ReadKey();
        }
        private void DisplayDeveloperDetails(DeveloperPoco developer)
        {
            Console.WriteLine($"DeveloperID: {developer.ID}\n" +
                              $"Developer Name:{developer.FullName}\n" +
                              $"Developer Has PluralSight: {developer.HasPluralSightAccount}\n");
        }
        private void GiveMeDevelopers()
        {
            Console.Clear();

            List<DeveloperPoco> developersToView = _devRepo.GetDevelopers().ToList();

            if (developersToView.Count == 0)
            {
                Console.WriteLine("There aren't any available existing Developers.");
            }
            else
            {

            }
            Console.ReadKey();
        }
    }
}