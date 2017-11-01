using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncResourceLoadTask : AsyncTask
    {
        private readonly ResourceRequest _resourceRequest;
        private Action<UnityEngine.Object> _action;
        public AsyncResourceLoadTask(Action<UnityEngine.Object> action, string path)
        {
            _action = action;
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
            _action(_resourceRequest.asset);
        }
    }
}