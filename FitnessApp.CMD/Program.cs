using FitnessApp.CMD.Controler;
using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the the FitnessWorld!");

            Console.WriteLine("Enter user name:");
            var name = Console.ReadLine();


            var userController = new UserController(name);
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
            Console.ReadLine();

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
