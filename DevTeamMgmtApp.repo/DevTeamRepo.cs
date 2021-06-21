using DevTeamMgmtApp.poco;
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

        //Read 
        public List<DevTeamPoco> GetDevTeamsList()
        {
            return _listOfDevTeams;
        }
        //Update or add DevTeam to List
        public bool UpdateDevTeamList(string devTeamId, DevTeamPoco newDevTeamPoco)
        {
            DevTeamPoco devTeam = GetDevTeamById(devTeamId);

            if (devTeam != null)
            {
                devTeam.Developers = newDevTeamPoco.Developers;
                devTeam.TeamNames = newDevTeamPoco.TeamNames;
                devTeam.TeamId = newDevTeamPoco.TeamId;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete - not required

        //helper method
        private DevTeamPoco GetDevTeamById(string devTeamId)
        {
            foreach (DevTeamPoco devTeam in _listOfDevTeams)
            {
                if (devTeam.TeamId == devTeamId)
                {
                    return devTeam;
                }
            }
            return null;

        }
    }
}
