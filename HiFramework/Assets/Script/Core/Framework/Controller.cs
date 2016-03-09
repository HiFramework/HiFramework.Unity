//****************************************************************************
// Description:控制逻辑
// Author: hiramtan@qq.com
//****************************************************************************
using System;
namespace HiFramework
{
    public abstract class Controller : Manager, IController
    {
        private bool disposed = false;
        public View view { get; private set; }
        public void Init(View param)
        {
            view = param;
        }
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
        }
        public void AddToTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }

        public void RemoveFromTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }

        public virtual void OnTick()
        {

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

            }
            disposed = true;
        }
    }
}
