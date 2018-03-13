//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    /// <summary>
    /// 不带参数的回调
    /// </summary>
    public abstract class AsyncTask : ITick
    {
        protected abstract bool IsDone { get; set; }
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