//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class View : MonoBehaviour, IView
    {
        protected IController controller;
        public void Bind<T>() where T : IController, new()
        {
            controller = new T();
            controller.Bind(this);
        }
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
    }
}

