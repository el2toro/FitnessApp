namespace FitnessApp.Bl.Controller.Tests
{
    internal class UserController
    {
        private string userName;

        public UserController(string userName)
        {
            this.userName = userName;
        }

        public object CurrentUser { get; internal set; }
    }
}