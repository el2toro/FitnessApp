using System;
using System.Security.Cryptography.X509Certificates;

namespace FitnessApp.CMD.Model
{
    class Gender
    {
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(" The name field can't be empty or white space");

            }

        }

        public override string ToString()
        {
            return Name;
        }

    }
}
