//****************************************************************************
// Description: 异步加载
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


        public override void Tick(float deltaTime)
        {
            if (_resourceRequest.isDone)
                Done();
        }

        protected override void Done()
        {
            base.Done();
            Action(_resourceRequest.asset);
        }

    }
}
//void Test()
//{
//new AsyncResourceLoadTask((x) =>
//{
//    var go = UnityEngine.Object.Instantiate(x) as GameObject;
//}, "path");
//}