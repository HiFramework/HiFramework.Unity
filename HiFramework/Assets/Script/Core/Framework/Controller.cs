using System;

namespace HiFramework
{
    public class Controller : IController, IMessage
    {
        public static Action<Message> viewEventHandler;

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch<T>(paramKey, paramMessage);
        }

        public virtual void OnMessage(Message paramMessage)
        {

        }

        public void Register<T>(object paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public void Remove(object paramKey)
        {
            Facade.Mediator.Remove(paramKey);
        }
    }
}
