using System;

namespace HiFramework
{
    public abstract class AsyncTask : ITick
    {
        protected Action<object> Action;
        protected object Obj;
        protected bool IsDone;
        private readonly IAsyncComponent _iAsyncComponent;
        protected AsyncTask()
        {
            _iAsyncComponent = Center.Get<AsyncComponent>();
            _iAsyncComponent.RegistTick(this);
        }

        public virtual void Tick()
        {
            if (IsDone)
            {
                _iAsyncComponent.UnRegistTick(this);
                Done();
                return;
            }
            OnTick();
        }

        protected abstract void OnTick();

        protected abstract void Done();
    }
}