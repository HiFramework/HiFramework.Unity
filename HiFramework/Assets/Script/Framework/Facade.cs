namespace HiFramework
{
    public class Facade
    {
        private static IController controller;
        public static IController Controller
        {
            get
            {
                if (controller == null)
                    controller = new ControllerMediator();
                return controller;
            }
        }

        private static IView view;
        public static IView View
        {
            get
            {
                if (view == null)
                    view = new ViewMediator();
                return view;
            }
        }
    }
}