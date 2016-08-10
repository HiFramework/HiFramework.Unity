//****************************************************************************
// Description:从mono拆分,view管理
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public class View : IActor, IView
    {
        public GameObject gameObject { get; private set; }
        private bool disposed = false;
        public Controller controller;

        public virtual void OnMessage(Message paramMessage)
        {
        }
        public void AddToTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }
        public void RemoveFromTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }

        public virtual void OnTick()
        {

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~View()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                MonoBehaviour.Destroy(gameObject);
                controller = null;
            }
            disposed = true;
        }
    }
}

