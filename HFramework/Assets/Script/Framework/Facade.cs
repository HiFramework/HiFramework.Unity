namespace HFramework
{
    public class Facade
    {
        private static Controller controller;
        public static Controller Controller
        {
            get
            {
                if (controller == null)
                    controller = new Controller();
                return controller;
            }
        }

    }
}