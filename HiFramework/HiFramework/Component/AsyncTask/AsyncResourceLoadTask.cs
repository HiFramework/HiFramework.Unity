using System;
using UnityEngine;

namespace HiFramework
{
    internal class AsyncResourceLoadTask : AsyncTask
    {
        private readonly ResourceRequest _resourceRequest;

        public AsyncResourceLoadTask(Action<object> action, string path)
        {
            Action = action;
            _resourceRequest = Resources.LoadAsync(path);
        }

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