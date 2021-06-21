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
        private List<DeveloperPoco> _listOfDevelopers = new List<DeveloperPoco>();

        //Create
        public void AddDeveloperToList(DeveloperPoco developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //Read
        public List<DeveloperPoco> GetDevelopersList()
        {
            return _listOfDevelopers;
        }
        //Update 
        public bool UpdateExistingDeveloper(string developerId, DeveloperPoco newDeveloperPoco)
        {
            DeveloperPoco developerPoco = GetDeveloperById(developerId);

            if (developerPoco != null)
            {
                developerPoco.Id = newDeveloperPoco.Id;
                developerPoco.FirstName = newDeveloperPoco.FirstName;
                developerPoco.LastName = newDeveloperPoco.LastName;
                developerPoco.AccessToPluralSight = newDeveloperPoco.AccessToPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool RemoveDeveloperfromList(string id)
        {
            DeveloperPoco developerPoco = GetDeveloperById(id);

            if (id == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developerPoco);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper method
        private DeveloperPoco GetDeveloperById(string id)
        {
            foreach (DeveloperPoco developer in _listOfDevelopers)
            {
                if (developer.Id == id)
                {
                    return developer;
                }
            }
            return null;

        }

    }

    
    

}