using DevTeamMgmtApp.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamMgmtApp.repo
{
    public class DeveloperRepo
    {
        //create List & name it
        private readonly List<DeveloperPoco> _developerRepo = new List<DeveloperPoco>();

        //make int value to increase to establish id
        private int _count = 0;

        //CRUD Create
        public bool AddDeveloper(DeveloperPoco developerPoco)
        {
            if (developerPoco is null)
            {
                return false;
            }
            _count++;
            developerPoco.Id = _count;
            _developerRepo.Add(developerPoco);

            return true;
        }
        public IEnumerable<DeveloperPoco> GetDevelopers()
        {
            return _developerRepo;
        }
        public DeveloperPoco GetDeveloperByID(int id)
        {
            foreach (var developerPoco in _developerRepo)
            {
                if (developerPoco.Id == id)
                {
                    return developerPoco;
                }
            }
            return null;
        }
        public bool UpdateDeveloper(int id, DeveloperPoco newDeveloperData)
        {
            DeveloperPoco developerPoco = GetDeveloperByID(id);
            if (developerPoco==null)
            {
                return false;
            }

            developerPoco.FirstName = newDeveloperData.FirstName;
            developerPoco.LastName = newDeveloperData.LastName;
            developerPoco.Id = id;
            developerPoco.DevTeam = newDeveloperData.DevTeam;
            developerPoco.AccessToPluralSight = newDeveloperData.AccessToPluralSight;

            return true;
        }

        public bool DeleteDeveloper(int id)
        {
            foreach (DeveloperPoco developerPoco in _developerRepo)
            {
                if (developerPoco.Id==id)
                {
                    _developerRepo.Remove(developerPoco);
                    return true;
                }           
            }
            return false;
        }
    }   
}

        