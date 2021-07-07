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
        //1.  create the fake database & name it
        private readonly List<DevTeamPoco> _devTeamRepo = new List<DevTeamPoco>();

        //2.  make int value to increase to establish TeamID
        private int _count = 0;

        //3.  CRUD - Create - add dev teams to the list
        public bool AddTeam(DevTeamPoco devTeamPoco)
        {
            if (devTeamPoco is null)
            {
                return false;
            }
            //increment _count
            _count++;

            //assign _count to the teamId
            devTeamPoco.TeamId = _count;

            //add devTeam to the database
            _devTeamRepo.Add(devTeamPoco);

            //we can just return true
            return true;
        }

        //4.  get all of devteams w/n the database and store them as a collection
        public IEnumerable<DevTeamPoco> GetDevTeams()
        {
            return _devTeamRepo;
        }

        //5.  get a single devteam
        public DevTeamPoco GetDevTeamById(int id)
        {
            //loop thru teams in database
            foreach (var devTeamPoco in _devTeamRepo)
            {
                //if team in database has same ID number as the ID number tat the user "passes-in"
                if (devTeamPoco.TeamId == id)
                {
                    //return specific team if true...    
                    return devTeamPoco;
                }
            }
            //else return nothing
            return null;
        }
        //6.  Update a team
        public bool UpdateDevTeam(int id, DevTeamPoco newDevTeamData)
        {
            //get a specific team
            DevTeamPoco devTeamPoco = GetDevTeamById(id);

            if (devTeamPoco == null)
            {
                return false;
            }

            devTeamPoco.TeamId = id;
            devTeamPoco.TeamName = newDevTeamData.TeamName;
            devTeamPoco.Developers = newDevTeamData.Developers;

            return true;
        }
        //7.  Delete Team

        public bool DeleteDevTeam(int teamId)
        {

            foreach (DevTeamPoco devTeamPoco in _devTeamRepo)
            {
                if (devTeamPoco.TeamId == teamId)
                {
                    _devTeamRepo.Remove(devTeamPoco);
                    return true;
                }
            }
            return false;
        }
    }
}





