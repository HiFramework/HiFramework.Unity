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
    }






    public class AsyncMutiTask
    {
        private AsyncMutiTask child;

        public AsyncMutiTask SetTask(AsyncMutiTask p)
        {
            child = p;
            return this;
        }

        void E()
        {
            if (child != null)
                child.E();
        }
    }


    public class tttt
    {
        void test()
        {
            var task = new AsyncMutiTask();
            for (int i = 0; i < 10; i++)
            {
                task.SetTask(null);
            }
        }
    }
}