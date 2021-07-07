using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.poco
{
    public class DevTeam
    {
        public List <Developer> Developers { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }


        public DevTeam() { }
        public DevTeam( string teamName, List<Developer> developers)
        {
            Developers = developers;
            TeamName = teamName;
            
        }
    }
 }
