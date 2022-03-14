using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {    
        private TeamRepo _repo = new TeamRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void Menu()
        {
            //Start with the main menu here
            //Menu options we'll need and the methods you'll need to make
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like:\n" +
                    "1. Display\n" +
                    "2. Search\n" +
                    "3. Add\n" +
                    "4. Modify\n" +
                    "5. Remove\n" +
                    "6. Exit");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        Display();
                        break;
                    case "2":
                        Search();
                        break;
                    case "3":
                        Add();
                        break;
                    case "4":
                        Modify();
                        break;
                    case "5":
                        Remove();
                        break;
                    case "6":
                    case "e":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 6.");
                        AnyKey();
                        break;
                }
            }
        }
        // Create
        private void Add()
        {
            bool addMenu = true;
            while (addMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Add Developer\n" +
                        "2. Add Team\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        //Add Developer
                        AddDev();
                        break;
                    case "2":
                        //Add Team
                        AddTeam();
                        break;
                    case "3":
                        //Go back
                        addMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        AnyKey();
                        break;
                }
            }
        }
        private void AddDev()
        {
            bool anotherone = true;
            while (anotherone)
            {
                Console.Clear();
                Developer dev = new Developer();
                // FirstName
                Console.Write("Please enter a first name: ");
                dev.FirstName = Console.ReadLine();
                // LastName
                Console.Write("Please enter a last name: ");
                dev.LastName = Console.ReadLine();
                // ID
                bool checkingiD = true;
                while (checkingiD)
                {
                    Console.Write("Please enter an ID for the developer: ");
                    int iD;
                    string user = Console.ReadLine();
                    if (!int.TryParse(user, out iD))
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid id!");
                    }
                    else
                    {
                        var existing = _repo.GetDevById(int.Parse(user));
                        if (existing == null)
                        {
                            dev.DeveloperId = int.Parse(user);
                            checkingiD = false;
                        }
                        else
                        {
                            Console.WriteLine("That ID is taken");
                        }
                    }
                }
                // License
                bool license = true;
                while (license)
                {
                    Console.WriteLine("Please state if the developer has a Pluaralsight license: ");
                    Console.WriteLine("1. yes\n" +
                            "2. no\n");
                    string user = Console.ReadLine();
                    switch (user)
                    {
                        case "1":
                        case "yes":
                        case "y":
                            dev.Pluralsight = License.Yes;
                            license = false;
                            break;
                        case "2":
                        case "no":
                        case "n":
                            dev.Pluralsight = License.No;
                            license = false;
                            break;
                        default:
                            Console.WriteLine("Please enter either yes or no.");
                            AnyKey();
                            break;
                    }
                }
                // Skillset
                bool skillset = true;
                while (skillset)
                {
                    Console.WriteLine("Please state the skillset the developer: ");
                    Console.WriteLine("1. frontend\n" +
                            "2. backend\n" +
                            "3. testing");
                    string user = Console.ReadLine();
                    switch (user)
                    {
                        case "1":
                        case "frontend":
                            dev.SkillSet = Skillset.FrontEnd;
                            skillset = false;
                            break;
                        case "2":
                        case "backend":
                            dev.SkillSet = Skillset.BackEnd;
                            skillset = false;
                            break;
                        case "3":
                        case "testing":
                            dev.SkillSet = Skillset.Testing;
                            skillset = false;
                            break;
                        default:
                            Console.WriteLine("Please select a valid number from 1 to 3.");
                            AnyKey();
                            break;
                    }
                }
                _repo.AddDeveloperToDirectory(dev);
                Console.WriteLine("Developer was successfully added!");
                // Adding Multiple Devs
                Console.WriteLine("Would you like to add another dev?");
                Console.WriteLine("1. yes\n" +
                    "2. no");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                    case "yes":
                    case "y":
                        Console.Clear();
                        break;
                    case "2":
                    case "no":
                    case "n":
                        anotherone = false;
                        break;
                    default:
                        Console.WriteLine("Please enter either yes or no.");
                        AnyKey();
                        break;
                }
            }
        }
        private void AddTeam()
        {
            bool anotherone = true;
            while (anotherone)
            {
                Console.Clear();
                Team team = new Team();
                // Teamname
                Console.Write("Please enter a team name: ");
                team.TeamName = Console.ReadLine();
                // ID
                bool checkingiD = true;
                while (checkingiD)
                {
                    Console.Write("Please enter an ID for the team: ");
                    int iD;
                    string user = Console.ReadLine();
                    if (!int.TryParse(user, out iD))
                    {
                        Console.WriteLine("Please enter a valid id!");
                        return;
                    }
                    var existing = _repo.GetDevTeamById(int.Parse(user));
                    if (existing == null)
                    {
                        team.TeamId = int.Parse(user);
                        checkingiD = false;
                    }
                    else
                    {
                        Console.WriteLine("That ID is taken");
                    }
                }
                _repo.AddTeamsToDir(team);
                Console.WriteLine("Team was successfully added!");
                // Adding Multiple Teams
                Console.WriteLine("Would you like to add another team?");
                Console.WriteLine("1. yes\n" +
                    "2. no");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                    case "yes":
                    case "y":
                        Console.Clear();
                        break;
                    case "2":
                    case "no":
                    case "n":
                        anotherone = false;
                        break;
                    default:
                        Console.WriteLine("Please enter either yes or no.");
                        AnyKey();
                        break;
                }
            }
        }
        // Read
        private void Display()
        {
            bool displaymenu = true;
            while (displaymenu)
            {
                Console.Clear();
                Console.WriteLine("1. Show all developers\n" +
                        "2. Show all teams\n" +
                        "3. Show developers without Pluralsight licence\n" +
                        "4. Back");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        //Show all developers
                        DisplayDevBasicInfo();
                        break;
                    case "2":
                        //Show all teams
                        DisplayTeamBasicInfo();
                        break;
                    case "3":
                        //Show all developers without Pluralsight licence
                        NoLicense();
                        break;
                    case "4":
                        //Go back
                        displaymenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 4.");
                        AnyKey();
                        break;
                }
            }
        }
        private void DisplayDevBasicInfo()
        {
            Console.Clear();
            List<Developer> listofDevs = _repo.GetDevelopers();
            foreach (Developer dev in listofDevs)
            {
                DisplayDevBasic(dev);
            }
            AnyKey();
        }
        private void DisplayTeamBasicInfo()
        {
            Console.Clear();
            List<Team> listofTeams = _repo.GetTeams();
            foreach (Team team in listofTeams)
            {
                DisplayTeamBasic(team);
            }
            AnyKey();
        }
        private void NoLicense()
        {
            Console.Clear();
            List<Developer> listofDevs = _repo.GetDevByLicense(pluralsight: License.No);
            foreach (Developer dev in listofDevs)
            {
                DisplayDevBasic(dev);
            }
            AnyKey();
        }
        private void Search()
        {
            bool searchMenu = true;
            while (searchMenu)
            {
                Console.Clear();
                Console.WriteLine("1. By Developers\n" +
                        "2. By Teams\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        //Search Devs by ID
                        SearchDevByID();
                        break;
                    case "2":
                        //Search Teams by ID
                        SearchTeamByID();
                        break;
                    case "3":
                        //Go back
                        searchMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        AnyKey();
                        break;
                }
            }
        }
        private void SearchDevByID()
        {
            Console.Clear();
            bool search = true;
            while (search)
            {
                Console.Write("Please enter an ID of a Developer you want to search for: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number!");
                }
                else
                {
                    search = false;
                    int idSearch = int.Parse(user);
                    Developer dev = _repo.GetDevById(idSearch);
                    if (dev != null)
                    {
                        DisplayDevFull(dev);
                        search = false;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find developer by that ID");
                        search = false;
                    }
                    AnyKey();
                }
            }
        }
        private void SearchTeamByID()
        {
            Console.Clear();
            bool search = true;
            while (search)
            {
                Console.Write("Please enter an ID of a Team you want to search for: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number!");
                }
                else
                {
                    search = false;
                    int idSearch = int.Parse(user);
                    Team team = _repo.GetDevTeamById(idSearch);
                    if (team != null)
                    {
                        DisplayTeamFull(team);
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find team by that ID");
                    }
                    AnyKey();
                }
            }
        }
        //Update
        private void Modify()
        {
            bool modMenu = true;
            while (modMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Modify Developer\n" +
                    "2. Modify Team\n" +
                    "3. Back");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        //Modify Developer
                        ModDev();
                        break;
                    case "2":
                        //Modify Team
                        ModTeam();
                        break;
                    case "3":
                        //Go back
                        modMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        AnyKey();
                        break;
                }
            }
        }            
        private void ModDev()
        {
            Console.Clear();
            bool moding = true;
            while (moding)
            {
                Console.Write("Please enter an ID of a Developer you want modify: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number!");
                }
                else
                {
                    moding = false;
                    int idSearch = int.Parse(user);
                    Developer oldDev = _repo.GetDevById(idSearch);
                    if (oldDev != null)
                    {
                        Console.Clear();
                        DisplayDevFull(oldDev);
                        // Mod FirstName
                        Console.Write("Please enter a first name: ");
                        oldDev.FirstName = Console.ReadLine();
                        // Mod LastName
                        Console.Write("Please enter a last name: ");
                        oldDev.LastName = Console.ReadLine();
                        // Mod ID
                        bool yesorno = true;
                        while (yesorno)
                        {
                            Console.WriteLine("Do you want to change the ID?:\n" +
                                "1. yes\n" +
                                "2. no");
                            string userentry = Console.ReadLine();
                            switch (userentry)
                            {
                                case "1":
                                case "yes":
                                case "y":
                                    bool checkinganother = true;
                                    while (checkinganother)
                                    {
                                        Console.Write("Please enter an new ID for the developer: ");
                                        int I;
                                        string read = Console.ReadLine();
                                        if (!int.TryParse(read, out I))
                                        {
                                            Console.WriteLine("Please enter a valid id!");
                                            return;
                                        }
                                        else
                                        {
                                            var existing = _repo.GetDevById(int.Parse(read));
                                            if (existing == null)
                                            {
                                                oldDev.DeveloperId = int.Parse(read);
                                                checkinganother = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("That ID is taken");
                                            }
                                        }
                                    }
                                    yesorno = false;
                                    break;
                                case "2":
                                case "no":
                                case "n":
                                    yesorno = false;
                                    break;
                                default:
                                    Console.WriteLine("Please enter either yes or no.");
                                    AnyKey();
                                    break;
                            }
                        }
                        // Mod License
                        bool license = true;
                        while (license)
                        {
                            Console.WriteLine("Please state if the developer has a Pluaralsight license: ");
                            Console.WriteLine("1. yes\n" +
                                    "2. no\n");
                            string reading = Console.ReadLine();
                            switch (reading)
                            {
                                case "1":
                                case "yes":
                                case "y":
                                    oldDev.Pluralsight = License.Yes;
                                    license = false;
                                    break;
                                case "2":
                                case "no":
                                case "n":
                                    oldDev.Pluralsight = License.No;
                                    license = false;
                                    break;
                                default:
                                    Console.WriteLine("Please enter either yes or no.");
                                    AnyKey();
                                    break;
                            }
                        }
                        // Skillset
                        bool skillset = true;
                        while (skillset)
                        {
                            Console.WriteLine("Please state the skillset the developer: ");
                            Console.WriteLine("1. frontend\n" +
                                    "2. backend\n" +
                                    "3. testing");
                            string reader = Console.ReadLine();
                            switch (reader)
                            {
                                case "1":
                                case "frontend":
                                    oldDev.SkillSet = Skillset.FrontEnd;
                                    skillset = false;
                                    break;
                                case "2":
                                case "backend":
                                    oldDev.SkillSet = Skillset.BackEnd;
                                    skillset = false;
                                    break;
                                case "3":
                                case "testing":
                                    oldDev.SkillSet = Skillset.Testing;
                                    skillset = false;
                                    break;
                                default:
                                    Console.WriteLine("Please select a valid number from 1 to 3.");
                                    AnyKey();
                                    break;
                            }
                        }
                        moding = false;
                        Console.WriteLine("Developer was updated!");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find developer by that ID");
                    }       
                }
                AnyKey();
            }
        }
        private void ModTeam()
        {
            Console.Clear();
            bool moding = true;
            while (moding)
            {
                Console.Write("Please enter an ID of a Team you want modify: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number!");
                }
                else
                {
                    moding = false;
                    int idSearch = int.Parse(user);
                    Team oldTeam = _repo.GetDevTeamById(idSearch);
                    if (oldTeam != null)
                    {
                        Console.Clear();
                        DisplayTeamFull(oldTeam);
                        // Mod TeamName
                        Console.Write("Please enter a team name: ");
                        oldTeam.TeamName = Console.ReadLine();
                        // Mod ID
                        bool yesorno = true;
                        while (yesorno)
                        {
                            Console.WriteLine("Do you want to change the ID?:\n" +
                                "1. yes\n" +
                                "2. no");
                            string userentry = Console.ReadLine();
                            switch (userentry)
                            {
                                case "1":
                                case "yes":
                                case "y":
                                    bool checkinganother = true;
                                    while (checkinganother)
                                    {
                                        Console.Write("Please enter an new ID for the team: ");
                                        int I;
                                        string read = Console.ReadLine();
                                        if (!int.TryParse(read, out I))
                                        {
                                            Console.WriteLine("Please enter a valid id!");
                                            return;
                                        }
                                        else
                                        {
                                            var existing = _repo.GetDevTeamById(int.Parse(read));
                                            if (existing == null)
                                            {
                                                oldTeam.TeamId = int.Parse(read);
                                                checkinganother = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("That ID is taken");
                                            }
                                        }
                                    }
                                    yesorno = false;
                                    break;
                                case "2":
                                case "no":
                                case "n":
                                    yesorno = false;
                                    break;
                                default:
                                    Console.WriteLine("Please enter either yes or no.");
                                    AnyKey();
                                    break;
                            }
                        }
                        // Modify members on team
                        bool modMembers = true;
                        while (modMembers)
                        {
                            Console.WriteLine("Would you like to: ");
                            Console.WriteLine("1. Add a member\n" +
                                    "2. Remove a member\n" +
                                    "3. Neither");
                            string reader = Console.ReadLine();
                            switch (reader)
                            {
                                case "1":
                                    bool addToTeam = true;
                                    while (addToTeam)
                                    {
                                        Console.Write("Please enter an ID of a Developer you want to add: ");
                                        int anotherID;
                                        string devInput = Console.ReadLine();
                                        if (!int.TryParse(devInput, out anotherID))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please enter a number!");
                                        }
                                        else
                                        {
                                            addToTeam = false;
                                            int ID = int.Parse(devInput);
                                            Developer dev = _repo.GetDevById(ID);
                                            if (dev != null)
                                            {
                                                if (_repo.AddDevloperToTeamById(ID, idSearch) == true)
                                                {
                                                    Console.WriteLine("That developer was added to the team.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("That developer is already in the team.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Couldn't find developer by that ID");
                                            }
                                        }
                                        
                                    }
                                    modMembers = false;
                                    break;
                                case "2":
                                    bool removefromTeam = true;
                                    while (removefromTeam)
                                    {
                                        Console.Write("Please enter an ID of a Developer you want to remove: ");
                                        int anotherID;
                                        string devInput = Console.ReadLine();
                                        if (!int.TryParse(devInput, out anotherID))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please enter a number!");
                                        }
                                        else
                                        {
                                            removefromTeam = false;
                                            int ID = int.Parse(devInput);
                                            Developer dev = _repo.GetDevById(ID);
                                            if (dev != null)
                                            {
                                                if (_repo.RemoveDeveloperFromTeamByID(ID, idSearch) == true)
                                                {
                                                    Console.WriteLine("That developer was added to the team.");                                           
                                                }
                                                else
                                                {
                                                    Console.WriteLine("That developer isn't on the team.");                                                    
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Couldn't find developer by that ID");                                              
                                            }  
                                        }                                      
                                    }
                                    modMembers = false;
                                    break;
                                case "3":
                                    modMembers = false;
                                    break;
                                default:
                                    Console.WriteLine("Please select a valid number from 1 to 3.");
                                    AnyKey();
                                    break;
                            }
                        }
                        moding = false;
                        Console.WriteLine("Team was updated!");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find team by that ID");
                    }
                }
                AnyKey();
            }
        }
        //Delete
        private void Remove()
        {
            bool addMenu = true;
            while (addMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Remove Developer\n" +
                        "2. Remove Team\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        //Remove Developer
                        RemoveDev();
                        break;
                    case "2":
                        //Remove Team
                        RemoveTeam();
                        break;
                    case "3":
                        //Go back
                        addMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        AnyKey();
                        break;
                }
            }
        }
        private void RemoveDev()
        {
            bool removing = true;
            while (removing)
            {
                Console.Write("Please enter the ID of the Developer you wish to remove: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid id!");
                }
                else
                {
                    int idSearch = int.Parse(user);
                    Developer dev = _repo.GetDevById(idSearch);
                    if (dev != null)
                    {
                        _repo.DeleteExistingDev(dev);
                        Console.WriteLine("Developer was deleted!");
                        removing = false;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find developer by that ID");
                        removing = false;
                    }
                }
            }          
            AnyKey();
        }
        private void RemoveTeam()
        {
            bool removing = true;
            while (removing)
            {
                Console.Write("Please enter the ID of the Team you wish to remove: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid id!");
                }
                else
                {
                    int idSearch = int.Parse(user);
                    Team team = _repo.GetDevTeamById(idSearch);
                    if (team != null)
                    {
                        _repo.DeleteExistingDevTeam(team);
                        Console.WriteLine("Team was deleted!");
                        removing = false;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find developer by that ID");
                        removing = false;
                    }
                }
            }  
            AnyKey();
        }
        private void SeedContent()
        // Preadding some devs and teams to the program
        {
            Developer john = new Developer(117, "John", "Halo", License.Yes, Skillset.BackEnd);
            Developer link = new Developer(49, "Link", "Past", License.Yes, Skillset.FrontEnd);
            Developer jessie = new Developer(78, "Jessie", "Rocket", License.No, Skillset.Testing);
            Developer thanos = new Developer(99, "Thanos", "Titan", License.No, Skillset.Testing);
            Developer billy = new Developer(88, "Billy", "Bob", License.Yes, Skillset.FrontEnd);
            Team red = new Team(3, "Red");
            Team blue = new Team(55, "Blue", new List<Developer> { link, jessie });
            Team green = new Team(33, "Green", new List<Developer> { link, thanos, john });
            _repo.AddDeveloperToDirectory(john);
            _repo.AddDeveloperToDirectory(link);
            _repo.AddDeveloperToDirectory(jessie);
            _repo.AddDeveloperToDirectory(thanos);
            _repo.AddDeveloperToDirectory(billy);
            _repo.AddTeamsToDir(red);
            _repo.AddTeamsToDir(blue);
            _repo.AddTeamsToDir(green);
        }
        private void DisplayDevBasic(Developer content)
        {
            Console.WriteLine($"Name: {content.FirstName} {content.LastName}\n" +
               $"ID: {content.DeveloperId}");
            Console.WriteLine();
        }
        private void DisplayDevFull(Developer content)
        {
            Console.WriteLine($"Developer Name: {content.FirstName} {content.LastName}\n" +
               $"ID: {content.DeveloperId}\n" +
               $"Pluralsight License: {content.Pluralsight}\n" +
               $"Skillset: {content.SkillSet}");
            Console.WriteLine();
        }
        private void DisplayTeamBasic(Team content)
        {
            Console.WriteLine($"Team Name: {content.TeamName}\n" +
               $"Team ID: {content.TeamId}");
            Console.WriteLine();
        }
        private void DisplayTeamFull(Team content)
        {
            Console.WriteLine($"Team Name: {content.TeamName}\n" +
               $"Team ID: {content.TeamId}\n");
            foreach (var dev in content.TeamMembers)
            {
                 DisplayDevFull(dev);
            }
            Console.WriteLine();
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
