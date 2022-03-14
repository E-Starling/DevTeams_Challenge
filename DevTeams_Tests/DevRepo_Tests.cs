using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevTeamsRepo_Tests
    {

      
        
        private Developer _dev;
        private DeveloperRepo _repo;
        [TestInitialize]
        //Setting up some devs
        public void Setup()
        {
            _repo = new DeveloperRepo();
            _dev = new Developer(117, "John", "Halo");
            Developer dev = new Developer(50, "Sally", "Sue", License.Yes, Skillset.FrontEnd);
            _repo.AddDeveloperToDirectory(_dev);
            _repo.AddDeveloperToDirectory(dev);
        }
        [TestMethod]
        //Adding a Dev
        public void AddToDevDir_ShouldBeTrue()
        {
            Developer dev = new Developer(44,"Bill", "Gates");
            DeveloperRepo repo = new DeveloperRepo();
            bool addResult = repo.AddDeveloperToDirectory(dev);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //Seeing if list of developers has the dev just added
        public void GetDirectly_ShouldReturnCorrentCollection()
        {
            
           //Arrange
           Developer dev = new Developer(17, "Bob", "Joe");
           DeveloperRepo repo = new DeveloperRepo();
           repo.AddDeveloperToDirectory(dev);
           //Act
           List<Developer> devs = repo.GetDevelopers();
           bool dirhasdevs = devs.Contains(dev);
           
            //Assert
            Assert.IsTrue(dirhasdevs);
        
        }
       [TestMethod]
       //Searching dev in dir by ID
        public void GetDevById_ShouldReturnTrue()
        {
              Developer searchID = _repo.GetDevById(117);
              Assert.AreEqual(_dev, searchID);
        }
        [TestMethod]
        //Searching devs in dir by SkillSet
        public void GetDevsBySkillset_ShouldReturnTrue()
        {
            List<Developer> testingDevs = _repo.GetBySkillSet(Skillset.FrontEnd);
            bool dirhasdevs = testingDevs.Contains(_dev);
            Assert.IsTrue(dirhasdevs);
        }
        [TestMethod]
        //Searching devs in dir by License
        public void GetDevsByLicense_ShouldReturnTrue()
        {
            List<Developer> pluralsightDev = _repo.GetDevByLiscense(Liscense.Yes);
            bool dirhasdevs = pluralsightDev.Contains(_dev);
            Assert.IsTrue(dirhasdevs);
        }
        [TestMethod]
        //Deleting exiting Dev in Dir
        public void DeleteExistingDev_ShouldReturnTrue()
        {
            //Arange
            Developer dev = _repo.GetDevById(117);
            //
            bool removeDev = _repo.DeleteExistingDev(dev);
            Assert.IsTrue(removeDev);
        }
        //[TestMethod]
        //   public void UpdateExistingContent_ShouldReturnTrue()
        //   {
        //        // Arrange
        //       Developer updatedDev = new Developer(23,"Billy", "Bob",true, Skillset.FrontEnd);
        //        // Act
        //       bool devCompare = _repo.UpdateExistingContent(23, updatedDev);

        //          // Assert
        //       Assert.IsTrue(devCompare);
        //     }


    }
}
