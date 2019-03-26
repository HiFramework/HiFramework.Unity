/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public abstract class SignalBase : IDisposable
    {
        protected SignalComponent Component;
        public SignalBase(string name)
        {
            Component = Center.Get<SignalComponent>();
            Component.AddSignal(name, this);
        }
        /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
        public abstract void Dispose();
    }
}
