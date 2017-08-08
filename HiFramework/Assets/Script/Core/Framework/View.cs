//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class View : MonoBehaviour, IView
    {

        public IController Bind<T>() where T : IController, new()
        {
           var controller = new T();
            controller.Bind(this);
            return controller;
        }
        public abstract void OnTick();

        public abstract void OnMessage(Message paramMessage);
        public void AddToTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }
        public void RemoveFromTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }
    }
}

