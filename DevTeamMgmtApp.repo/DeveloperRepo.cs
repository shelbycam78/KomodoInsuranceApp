﻿using DevTeamMgmtApp.poco;
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

        //Create list of developers
        public void AddDeveloperToList(DeveloperPoco developer)
        {
            _listOfDevelopers.Add(developer);
        }
        //Read list of developers
        public List<DeveloperPoco> GetDevelopersList()
        {
            return _listOfDevelopers;
        }
        //Update list of developers
        public bool UpdateExistingListOf(string developerId, DeveloperPoco newDeveloperPoco)
        {
            DeveloperPoco developerPoco = GetDeveloperById(developerId);

            if (developerPoco != null)
            {
                developerPoco.FirstName = newDeveloperPoco.FirstName;
                developerPoco.LastName = newDeveloperPoco.LastName;
                developerPoco.Id = newDeveloperPoco.Id;
                developerPoco.DevTeam = newDeveloperPoco.DevTeam;
                developerPoco.AccessToPluralSight = newDeveloperPoco.AccessToPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDeveloperFromList(string id)
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
