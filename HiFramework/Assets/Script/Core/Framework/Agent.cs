//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class Agent : Manager, ILogic
    {
        private bool disposed;
        public void Dispatch(object paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch(paramKey, paramMessage);
        }

        public void Register<T>(object paramKey) where T : ILogic
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public abstract void OnTick();

        public abstract void OnMessage(Message paramMessage);

        public void Unregister(object paramKey)
        {
            Facade.Mediator.Unregister(paramKey);
        }
        public void AddToTickList()
        {
            Facade.GameTick.AddToTickList(this);
        }

        public void RemoveFromTickList()
        {
            Facade.GameTick.RemoveFromTickList(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Agent()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {

            }
            disposed = true;
        }
    }
}