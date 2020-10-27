

using System;
using System.Xml.Linq;

namespace FitnessApp.CMD.Model
{
    public class Exercise
    {
        public DateTime Start { get; }

        public DateTime Finish { get; }

        public Activity Activity { get; }

        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }


    }
}
