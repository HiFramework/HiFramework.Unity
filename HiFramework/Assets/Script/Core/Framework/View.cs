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
        protected void Dispatch(Message paramMessage)
        {
            Dispatch(this, paramMessage);
        }
        public void Register<T>(object paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }
        protected void Register<T>() where T : IController
        {
            Register<T>(this);
        }
        public virtual void OnTick(float paramTime)
        {

        }
        protected virtual void OnMessage(Message paramMessage)
        {

        }
        protected void Remove()
        {
            Remove(this);
        }
        public void Remove(object paramKey)
        {
            Facade.Mediator.Remove(paramKey);
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

