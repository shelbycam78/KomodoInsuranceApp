﻿using System;
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

        public string ID { get; set; }

        public string DevTeam { get; set; }

        public bool AccessToPluralSight { get; set; }

        public DeveloperPoco() {}

        public DeveloperPoco(string firstName, string lastName, string id, string devTeam, bool accessToPluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            DevTeam = devTeam;
            AccessToPluralSight = accessToPluralSight;

        }
             
        

    }
         
    }
}
