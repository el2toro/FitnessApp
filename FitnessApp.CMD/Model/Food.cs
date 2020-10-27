using System;
using System.Dynamic;

namespace FitnessApp.CMD.Model
{
    public class Food
    {
        public string Name { get; }

        public double Calories {get;}

        public double Proteins { get; }

        public double Fats { get; }

        public double Carbohydrates { get; }

        public Food(string name) : this (name, 0, 0, 0, 0) { }


        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }   

}
