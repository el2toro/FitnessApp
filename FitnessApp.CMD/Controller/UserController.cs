﻿using FitnessApp.CMD.Controller;
using FitnessApp.CMD.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.CMD.Controler
{
    class UserController : ControllerBase
    {
        public List<User>  Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can't be empty ot white space.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
       /// <summary>
       ///  ***************     Get user list    *************
       /// </summary>
       /// <returns></returns>

        private List<User> GetUsersData()
        {
            return Load<List<User>>("user.dat") ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.DateOfBirth = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Hight = height;
            Save();
        }

        public void Save()
        {
            Save("users.dat", Users);
        }

         /// <summary>
         ///    Retreave user data.
         /// </summary>
         /// <returns>User application</returns>

        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) 
            {
                return formatter.Deserialize(fs) as User;
    
            }
        }
    }
}
