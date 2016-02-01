namespace HFramework
{
    public class Facade
    {
        private static Facade instance;
        public static Facade Instance
        {
            get
            {
                if (instance == null)
                    instance = new Facade();
                return instance;
            }
        }

        public Controller controller;

        public void StartFramework()
        {
            if (controller == null)
                controller = new Controller();

        }


    }
}