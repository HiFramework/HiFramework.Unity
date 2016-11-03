//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class Agent : Manager, IAgent
    {
      
        public void Dispatch(object paramKey, Message paramMessage)
        {
            Facade.AgentFactory.Dispatch(paramKey, paramMessage);
        }

        public object Register<T>(object paramKey) where T : IAgent
        {
            return Facade.AgentFactory.Register<T>(paramKey);
        }

        public abstract void OnTick();

        public abstract void OnMessage(Message paramMessage);

        public void Unregister(object paramKey)
        {
            Facade.AgentFactory.Unregister(paramKey);
        }
        public void AddToTickList(ITick param)
        {
            Facade.GameTick.AddToTickList(param);
        }

        public void RemoveFromTickList(ITick param)
        {
            Facade.GameTick.RemoveFromTickList(param);
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
        private bool disposed;
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