using System;
using System.Collections.Generic;
using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevTeamRepo_Tests
    {
        
        private Developer _dev;
        private DeveloperRepo _devrepo;
        private Team _team;
        private TeamRepo _teamrepo;

        [TestInitialize]
        //Setting up some devs
        public void Setup()
        {
            _devrepo = new DeveloperRepo();
            Developer dev1 = new Developer(117, "John", "Halo");
            Developer dev2 = new Developer(50, "Sally", "Sue", License.Yes, Skillset.FrontEnd); //Episodes
            _devrepo.AddDeveloperToDirectory(dev1);
            _devrepo.AddDeveloperToDirectory(dev2);

            _teamrepo = new TeamRepo();
            
            Team red = new Team(55, "Red");
            Team blue = new Team(20, "Blue", new List<Developer>{ dev1, dev2});
            _teamrepo.AddTeamsToDir(red);
            _teamrepo.AddTeamsToDir(blue);

            
        }
        [TestMethod]
        public void ListingTeams()
        {
            List<Team> listofTeams = _teamrepo.GetTeams();
            foreach (Team content in listofTeams)
            {
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue...");

            void DisplayContent(Team content)
            {
                Console.WriteLine($"Team Name: {content.TeamName}\n" +
                   $"Team Id: {content.TeamId}\n" +
                   $" {content.TeamMembers}");
                Console.WriteLine();
            }

           
            
        }
    }
}
