﻿using System;
using System.Threading;

namespace FitnessApp.CMD.Model
{
    class User
    {
        #region Properties
        public string Name { get; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Weight { get; set; }

        public double Hight { get; set; }  
        
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        #endregion            
        public User(string name, 
                    Gender gender, 
                    DateTime dateOfBirth, 
                    double weight, 
                    double height)
        {
            #region Imput parameter check 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("User name can't be empty or white space.");
            }

            if (gender == null)
            {
                throw new ArgumentException("Gender can't be null.", nameof(gender));
            }

            if (dateOfBirth < DateTime.Parse("01.01.1900") || dateOfBirth >= DateTime.Now )
            {
                throw new ArgumentException("Date of birth is not valid.", nameof(dateOfBirth));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight can't be smaller or equal to zero.");
            }

            if (height <=0)
            {
                throw new ArgumentException("Height can't be smaller or equal to zero.");
            }
            #endregion 

            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Hight = height;

        }

        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(" The name field can't be empty or white space", nameof(name));

            }
        }
        
       
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
