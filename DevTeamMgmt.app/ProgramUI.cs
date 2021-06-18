using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmt.app
{
    class ProgramUI
    {
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
                        DisplayDevelopersById();
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

        //Creat new DevTeam
        private void CreateDevTeam()
        {
            
        }

        //Read or display all Developers by Id
        private void DisplayDevelopersById()
        {
            
        }
        //Read or display all DevTeams
        private void DisplayDevTeams()
        {
           
        }

        //Update or edit a Devteam
        private void EditDevTeam()
        {

        }

        //Delete or remove Developers - not required
        

    }
}
