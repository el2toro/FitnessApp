using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessApp.CMD.Controller.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void SetNewUserDateaTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears (- 18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = UserController(userName);
            controller.SetNewUserData();

            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.birthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.weight);
            Assert.AreEqual(height, controller2.CurrentUser.height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        

        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //
            Assert.AreEqual(userName, controller.CurrentUser.Name);


        }
    }
}
