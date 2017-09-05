//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************

using System;
using UnityEngine;

namespace HiFramework.Core.AsyncTask
{
    public class AsyncMutiResourceLoad : AsyncTask
    {
        private readonly string _path;
        private AsyncMutiResourceLoad _childTask;
        private Action<object> _oneFinishAction;

        private readonly ResourceRequest _resourceRequest;

        public AsyncMutiResourceLoad(string path)
        {
            _path = path;
            _resourceRequest = Resources.LoadAsync(path);
        }

        public AsyncMutiResourceLoad SetCount(int numb)
        {
            if (numb <= 0)
                throw new Exception("numb<=0");

            var task = this;
            for (var i = 0; i < numb; i++)
            {
                task._childTask = new AsyncMutiResourceLoad(_path);
                task = task._childTask;
            }
            return this;
        }

        public AsyncMutiResourceLoad OnOneFinish(Action<object> obj)
        {
            _oneFinishAction = obj;
            return this;
        }

        protected override void Tick()
        {
            if (_resourceRequest.isDone)
            {
                IsDone = true;
                if (_oneFinishAction != null)
                    _oneFinishAction(_resourceRequest.asset);
                if (_childTask != null)
                    _childTask.Start();
            }
        }

        protected override void Complate()
        {
            Action(null);
        }
    }
}

//public class TestAsyncMutiLoad : MonoBehaviour
//{
//    void Start()
//    {
//        //加载10个
//        new AsyncMutiResourceLoad("Resources/xxx").SetCount(10).OnOneFinish(OneFinish).OnFinish(Finish);
//    }

//    void OneFinish(object obj)
//    {
//        Debug.Log("加载一个完成:" + obj);
//    }

//    void Finish(object obj)
//    {
//        Debug.Log("全部加载结束");
//    }
//}