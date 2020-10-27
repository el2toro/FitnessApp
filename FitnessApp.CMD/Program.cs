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
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("date of birth");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - enter food to take");
            Console.WriteLine("A - enter an ecercise");
            Console.WriteLine("Q - quite");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);

                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t{item.Key} - {item.Value}");
                    }

                    break;
                case ConsoleKey.A:
                    var exe = EnterExercise();

                    exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                    foreach (var item in exerciseController.Exercises)
                    {
                        Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                    }
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;

            }

            Console.ReadLine();
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter name of exercise: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("energy consuming");

            var begin = ParseDateTime("exercise begining ");
            var end = ParseDateTime("ending exercise");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

            return (Food: product, Weght: weight);
        }



        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter your {value} (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{value} format is incorect.");
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
