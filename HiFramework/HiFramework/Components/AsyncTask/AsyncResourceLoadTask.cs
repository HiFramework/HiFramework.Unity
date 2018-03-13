//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HiFramework
{
    public class AsyncResourceLoadTask : AsyncTaskWithParam<Object>
    {
        private readonly ResourceRequest _resourceRequest;

        public AsyncResourceLoadTask(Action<Object> action, string path) : base(action)
        {
            _resourceRequest = Resources.LoadAsync(path);
        }

        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (_resourceRequest.isDone)
                IsDone = true;
        }

        protected override void Done()
        {
            Action(_resourceRequest.asset);
        }
    }
}