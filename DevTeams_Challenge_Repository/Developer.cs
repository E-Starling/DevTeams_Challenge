using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum Skillset { FrontEnd, BackEnd, Testing}
    public enum License { Yes, No}
    public class Developer
    {
        public Developer() { }      
        //Simple Developer
        public Developer (int iD, string firstName, string lastName)
        {
            DeveloperId = iD;
            FirstName = firstName;
            LastName = lastName;
        }
        //Detailed Developer
        public Developer(int iD, string firstName, string lastName, License pluralsight, Skillset skillset) : this(iD,firstName,lastName)
        {
            Pluralsight = pluralsight;
            SkillSet = skillset;
        }
        public int DeveloperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Skillset SkillSet { get; set; }
        public License Pluralsight { get; set; }
    }
}
