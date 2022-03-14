using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class Team
    {
        public Team() { }
        //Simple DevTeam
        public Team(int iD, string teamName)
        {
            TeamId = iD;
            TeamName = teamName;
        }
        //Detailed DevTeam
        public Team(int iD, string teamName,List<Developer> teamMembers) : this(iD, teamName)
        {
            TeamMembers = teamMembers;
        }
        public int TeamId { get; set; }
        public List<Developer> TeamMembers { get; set; }
        public string TeamName { get; set; }
    }
}
