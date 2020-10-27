
using FitnessApp.CMD.Model;
using System;
using System.Collections.Generic;

namespace FitnessApp.CMD.Controller
{ 
    [Serializable]
    public class ExerciseController : ControllerBase
    {
        private readonly User User;
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(typeof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activity.SingleOrDefault(a => a.Name == activity);
            if (act == null)
            {
                Activity.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercise.Add(exercise);
                Save();
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);
                Exercise.Add(exercise);
                
            }
            Save();
        }


        private List<Exercise> GetAllExercise()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }


    }
}
