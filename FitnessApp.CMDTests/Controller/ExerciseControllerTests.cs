using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.CMD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.CMD.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController();
            var exerciseController = new EatingController(userController.curentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50)),

            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);

        }
    }
}