//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
namespace HiFramework
{    /// <summary>
     /// 带参数的异步回调
     /// </summary>
     /// <typeparam name="T"></typeparam>
    public abstract class AsyncTaskWithParam<T> : AsyncTask
    {
        protected Action<T> Action;
        protected AsyncTaskWithParam(Action<T> action)
        {
            Action = action;
        }
    }
}
