using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.repo
{
    public class DevTeamRepo
    {
        private List<DevTeamPoco> _listOfDevTeams = new List<DevTeamPoco>();

        //Create a new DevTeam
        public void CreateDevTeam(DevTeamPoco devTeam)
        {
            _listOfDevTeams.Add(devTeam);
        }

        //Read - not required

        //Update or add DevTeam to List
        public void UpdateDevTeamList(string originalDevTeamPoco, DevTeamPoco newDevTeamPoco)
        {
            _listOfDevTeams.Add(DevTeamRepo);
                       
        }       
        
            //Delete - not required
    }
}
