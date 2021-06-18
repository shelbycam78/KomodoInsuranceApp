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
        public void UpdateExistingList(string originalDeveloperPoco, DeveloperPoco newDeveloperPoco, object Id)
        {
            DeveloperPoco DeveloperPoco = GetDevelopersList(Id);

            if (originalDeveloperPoco != null)
            {
                DeveloperPoco.Id = newDeveloperPoco.Id;
                DeveloperPoco.FirstName = newDeveloperPoco.FirstName;
                DeveloperPoco.LastName = newDeveloperPoco.LastName;
                DeveloperPoco.DevTeam = newDeveloperPoco.DevTeam;
                DeveloperPoco.AccessToPluralSight = newDeveloperPoco.AccessToPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool RemoveDeveloperfromList(string id);
        {
            DeveloperPoco id = GetDeveloperById(id);
    
            if (id == null)
                {
                    return false;
                }
     
            int initialcount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(DeveloperPoco);

            if (initialCount > _listofDevelopers.Count)
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
            foreach (DeveloperPoco idNumber in _listOfDeveloper) 
            {
                if (idNumber._listOfDevelopers == id)
                {
                    return id; 
                }
            }
            return null;
                      
        }

}