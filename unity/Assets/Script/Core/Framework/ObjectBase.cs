//****************************************************************************
// Description: 非mono组件基类
// 主要用于通用逻辑及销毁
// Author: hiramtan@live.com
//***************************************************************************

using System;

namespace HiFramework
{
    public abstract class ObjectBase : IDisposable
    {
        protected abstract void OnDispose();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ObjectBase()
        {
            Dispose(false);
        }
        private bool _disposed;
        private void Dispose(bool paramDisposing)
        {
            if (_disposed)
                return;
            if (paramDisposing)
            {
                OnDispose();
            }
            _disposed = true;
        }
    }
}