using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class TeamRepo : DeveloperRepo
    {
        protected List<Team> _TeamDir = new List<Team>();
        // Create
        public bool AddTeamsToDir(Team devTeam)
        {
            int startingCount = _TeamDir.Count();
            _TeamDir.Add(devTeam);
            bool wasAdded = (_TeamDir.Count() > startingCount) ? true : false;
            return wasAdded;
        }       
        // Read
        public List<Team> GetTeams()
        {
            return _TeamDir;
        }
        public Team GetDevTeamById(int teamId)
        {
            return _TeamDir.Where(t => t.TeamId == teamId).SingleOrDefault();
        }
        // Update
        public bool RemoveDeveloperFromTeamByID(int devId, int teamId)
        {
            Team dTeam = GetDevTeamById(teamId);
            Developer dev = dTeam.TeamMembers.Where(d => d.DeveloperId == devId).SingleOrDefault();
            if (dev != default)
            {
                return dTeam.TeamMembers.Remove(dev);
            }
            else
            {
                return false;
            }
        }
        public bool AddDevloperToTeamById(int devId, int teamId)
        {
            Developer dev = GetDevById(devId);

            Team dTeam = GetDevTeamById(teamId);

            if (dev != default && dTeam != default)
            {
                int startingCount = dTeam.TeamMembers.Count();
                dTeam.TeamMembers.Add(dev);
                return dTeam.TeamMembers.Count > startingCount ? true : false;
            }
            return false;
        }
        // Delete
        public bool DeleteExistingDevTeam(Team existingDevTeam)
        {
            bool deleteResult = _TeamDir.Remove(existingDevTeam);
            return deleteResult;
        }
    }
}
