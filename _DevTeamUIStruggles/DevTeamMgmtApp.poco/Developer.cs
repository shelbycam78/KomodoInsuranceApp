using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.poco
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get 
            {
                return $"{FirstName} {LastName}";
            } 
        }
        public int Id { get; set; }

        //this is to specify which team is assigned to the developer?
        public string DevTeam { get; set; }

        public bool AccessToPluralSight { get; set; }


        public Developer() {}
        public Developer(string firstName, string lastName,
                             string devTeam, bool accessToPluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            DevTeam = devTeam;
            AccessToPluralSight = accessToPluralSight;                      
        }

        public Developer(string firstName, 
                          string lastName
                         ,bool accessToPluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            
            AccessToPluralSight = accessToPluralSight;
        }
    }  
}
