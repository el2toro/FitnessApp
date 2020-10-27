

using FitnessApp.CMD.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.CMD.Controller
{
    public class EatingController
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty.",nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();

        }

    
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == foodName);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }


        }

        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

      

        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
