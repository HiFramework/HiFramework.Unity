//****************************************************************************
// Description: 实例对象,facade维护
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

    public class Proxy : IAgent
    {
        public void AddToTickList(ITick paramTick)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromTickList(ITick paramTick)
        {
            throw new NotImplementedException();
        }

        public void OnTick()
        {
            throw new NotImplementedException();
        }

        public object Register<T>(object paramKey) where T : IAgent
        {
            throw new NotImplementedException();
        }

        public void Unregister(object paramKey)
        {
            throw new NotImplementedException();
        }

        public void Dispatch(object paramKey, Message paramMessage = null)
        {
            throw new NotImplementedException();
        }

        public void OnMessage(Message paramMessage)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}