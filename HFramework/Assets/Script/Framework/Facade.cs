namespace HFramework
{
    public class Facade
    {
        private static ControllerMediator controllerMediator;
        public static ControllerMediator Controller
        {
            get
            {
                if (controllerMediator == null)
                    controllerMediator = new ControllerMediator();
                return controllerMediator;
            }
        }

        private static ViewMediator viewMediator;
        public static ViewMediator View
        {
            get
            {
                if (viewMediator == null)
                    viewMediator = new ViewMediator();
                return View;
            }
        }
    }
}