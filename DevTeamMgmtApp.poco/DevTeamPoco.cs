using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.poco
{
    public class DevTeamPoco
    {
        public List <DeveloperPoco> Developers { get; set; }
        public string TeamName { get; set; }
        public string TeamId { get; set; }


        public DevTeamPoco() { }
        public DevTeamPoco(List <DeveloperPoco> developers, string teamName, string teamId)
        {
            Developers = developers;
            TeamName = teamName;
            TeamId = teamId;
        }
    }
 }
