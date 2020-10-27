using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.CMD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.CMD.Model;

namespace FitnessApp.CMD.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController();
            var eatingController = new EatingController(userController.curentUser);
            var foof = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500)),
            
            //Act
            eatingController.Add(Food, 100);

            //Assert
            //Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);

             
        }
    }
}