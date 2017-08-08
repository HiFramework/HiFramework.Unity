using System;
using System.Collections;
using UnityEngine;


namespace HiFramework
{
    public class AsyncTask
    {
        private Executer executer;
        protected bool isDone;
        private Action<object> action;//任务完成后的事件

        private AsyncExecuter asyncExecuter;
        public AsyncTask()
        {
            executer = new Executer(this);
            asyncExecuter = GameObject.FindObjectOfType<AsyncExecuter>();
            if (asyncExecuter == null)
                asyncExecuter = new GameObject("AsyncExecuter").AddComponent<AsyncExecuter>();
        }

        //任务开始执行
        public AsyncTask Start()
        {
            asyncExecuter.StartCoroutine(executer);
            return this;
        }
        //任务结束后执行回调
        public void Finish(Action<object> param)
        {
            action = param;
        }

        protected virtual void Update()
        {
            //isDone = true;

        }

        protected virtual void _Complate()
        {
            action(null);
        }

        private class Executer : IEnumerator
        {
            private AsyncTask asyncTask;
            public Executer(AsyncTask param)
            {
                asyncTask = param;
            }

            public bool MoveNext()
            {
                if (!asyncTask.isDone)
                {
                    asyncTask.Update();
                    return true;
                }
                asyncTask._Complate();
                return false;

            }

            public void Reset()
            {
                //throw new System.NotImplementedException();
            }

            public object Current { get; private set; }
        }
    }

    public class AsyncExecuter : MonoBehaviour
    {

    }
}