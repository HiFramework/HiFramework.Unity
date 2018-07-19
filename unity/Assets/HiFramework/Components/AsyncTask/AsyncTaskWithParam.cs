/****************************************************************************
// Description: 有参数异步任务父类
// Author: hiramtan@live.com
*****************************************************************************/
using System;
namespace HiFramework
{
    public abstract class AsyncTaskWithParam<T> : ITick
    {
        private readonly AsyncComponent _iAsyncComponent;
        protected Action<T> Action;
        protected AsyncTaskWithParam(Action<T> action)
        {
            _iAsyncComponent = Center.Get<AsyncComponent>();
            _iAsyncComponent.RegistTick(this);
            Action = action;
        }

        public abstract void Tick();
        protected virtual void Done()
        {
            _iAsyncComponent.UnRegistTick(this);
        }
    }
}
