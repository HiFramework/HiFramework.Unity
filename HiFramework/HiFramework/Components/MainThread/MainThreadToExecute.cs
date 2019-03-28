//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    /// <summary>
    /// 待执逻辑
    /// </summary>
    class MainThreadToExecute : IDisposable
    {
        public Action<object> Action { get; private set; }
        public object Args { get; private set; }

        public MainThreadToExecute(Action<object> action, object args)
        {
            Action = action;
            Args = args;
        }
        /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
        public void Dispose()
        {
            Action = null;
            Args = null;
        }
    }
}
