//****************************************************************************
// Description:数据模型
// Author: hiramtan@qq.com
//****************************************************************************
using System;

namespace HiFramework
{
    public class Model : IModel
    {
        private bool disposed = false;
        public void Clear()
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Model()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                Clear();
            }
            disposed = true;
        }
    }
}