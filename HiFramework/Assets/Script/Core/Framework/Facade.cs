namespace HiFramework
{
    public class Facade
    {
        private static ICommand mediator;
        public static ICommand Mediator
        {
            get
            {
                if (mediator == null)
                    mediator = new Mediator();
                return mediator;
            }
        }
    }
}