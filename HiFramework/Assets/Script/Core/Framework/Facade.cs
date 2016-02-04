using System.Collections.Generic;
namespace HiFramework
{
    public class Facade
    {
        public static List<IView> tickList = new List<IView>();
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