//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections;
using UnityEngine;

namespace HiFramework
{
    public abstract class AsyncTask
    {
        protected bool IsDone { private get; set; } //任务是否完成
        protected Action<object> Action { get; private set; } //任务完成后的事件

        private Executer _executer;
        private MonoBehaviour _asyncExecuter;

        public AsyncTask()
        {
            _executer = new Executer(this);
            _asyncExecuter = GameWorld.Instance;
        }

        //任务开始执行
        public AsyncTask Start()
        {
            _asyncExecuter.StartCoroutine(_executer);
            return this;
        }

        public void OnFinish(Action<object> action = null)
        {
            Action = action;
        }

        protected abstract void Tick();
        //{
        //    //isDone = true;
        //}

        protected abstract void Complate();
        //{
        //    action(null);
        //}

        private class Executer : IEnumerator
        {
            private AsyncTask _asyncTask;

            public Executer(AsyncTask param)
            {
                _asyncTask = param;
            }

            public bool MoveNext()
            {
                if (!_asyncTask.IsDone)
                {
                    _asyncTask.Tick();
                    return true;
                }
                _asyncTask.Complate();
                return false;

            }

            public void Reset()
            {
                //throw new System.NotImplementedException();
            }

            public object Current { get; private set; }
        }





        public class AsyncMutiLoad : AsyncTask
        {
            private AsyncMutiLoad _childTask;
            private readonly string _path;

            private ResourceRequest _resourceRequest;

            public AsyncMutiLoad(string path)
            {
                _path = path;
                _resourceRequest = Resources.LoadAsync(path);
            }

            public AsyncMutiLoad SetCount(int numb)
            {
                if (numb <= 0)
                    throw new Exception("numb<=0");

                AsyncMutiLoad task = this;
                for (int i = 0; i < numb; i++)
                {
                    task._childTask = new AsyncMutiLoad(_path);
                    task = task._childTask;
                }
                return this;
            }

            protected override void Tick()
            {
                if (_resourceRequest.isDone && _childTask != null)
                {
                    _childTask.Start();
                }
                else
                {
                    IsDone = true;
                }
            }

            protected override void Complate()
            {
                Action(null);
            }
        }
    }
}