using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.poco
{
    public class DevTeamPoco
    {
        public string Developers { get; set; }

        public string TeamNames { get; set; }

        public string TeamId { get; set; }

        public DevTeamPoco(){}

        public DevTeamPoco(string developers, string teamNames, string teamId)
        {
            Developers = developers;
            TeamNames = teamNames;
            TeamId = teamId;

        }
    }
    
   
}
