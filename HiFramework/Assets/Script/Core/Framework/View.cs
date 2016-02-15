using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class View : MonoBehaviour, IView
    {
        private bool disposed = false;

        public void Dispatch(object paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch(this, paramMessage);
        }
        public void Register<T>(object paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public abstract void OnMessage(Message paramMessage);

        public void OnDestroy()
        {
            Unregister(this);
        }
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
        ~View()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                Destroy(this);
            }
            disposed = true;
        }
    }
}

