using System;

namespace HiFramework
{
    public abstract class Controller : IController
    {
        public Action<Message> viewEventHandler;
        private bool disposed = false;

        public void Dispatch(object paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch(paramKey, paramMessage);
        }

        public void Register<T>(object paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public abstract void OnMessage(Message paramMessage);

        public void Unregister(object paramKey)
        {
            Facade.Mediator.Unregister(paramKey);
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Controller()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                viewEventHandler = null;
            }
            disposed = true;
        }
    }
}
