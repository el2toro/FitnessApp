using FitnessApp.CMD.Controler;
using FitnessApp.CMD.Controller;
using FitnessApp.CMD.Languages;
using FitnessApp.CMD.Model;
using System;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Message", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();


            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - enter food to take");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                
            }

            Console.ReadLine();
        }

        private static  (Food Food, double Weight) EnterEating()
        {
             Console.Write("Enter food name: ")
            var food = Console.ReadLine();
            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbs");

            var weight = ParseDouble("weight of norm");
            var product = new Food(food, calories, proteins, fats, carbs);

            return new (product, weight);
        }



        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter your date of birth (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Date format is incorect.");
                }

            }

            return birthDate;
        }

        private static double  ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    
                }
                else
                {
                    Console.WriteLine($"Incorect format {name}.");
                }

            }
        }
    }
}
