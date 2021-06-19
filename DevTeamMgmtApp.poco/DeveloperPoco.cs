using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.poco
{
    public class DeveloperPoco
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public bool AccessToPluralSight { get; set; }

        public DeveloperPoco() {}

        public DeveloperPoco(string firstName, string lastName, string id, string devTeam, bool accessToPluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            AccessToPluralSight = accessToPluralSight;
            
          }
             
        

    }
        
}
