using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DeveloperRepo
    {
        protected readonly List<Developer> _developerDir = new List<Developer>();
        // Create
        public bool AddDeveloperToDirectory(Developer dev)
        {
            int startingCount = _developerDir.Count();
            _developerDir.Add(dev);
            bool wasAdded = (_developerDir.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        // Read
        public List<Developer> GetDevelopers()
        {
            return _developerDir;
        }
        public Developer GetDevById(int id)
        {
            return _developerDir.Where(d => d.DeveloperId == id).SingleOrDefault();
        }

        public List<Developer> GetBySkillSet(Skillset skillset)
        {
            return _developerDir.Where(d => d.SkillSet == skillset).ToList();
        }

        public List <Developer> GetDevByLicense(License pluralsight)
        {
            return _developerDir.Where(d => d.Pluralsight == pluralsight).ToList();
        }
        // Delete
        public bool DeleteExistingDev(Developer existingDev)
        {
            bool deleteResult = _developerDir.Remove(existingDev);
            return deleteResult;
        }
    }
}
