using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class View : MonoBehaviour, IView
    {
        public void Dispatch(object paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch(this, paramMessage);
        }

        public virtual void OnTick(float paramTime)
        {

        }

        public void Register<T>(object paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public void Remove(object paramKey)
        {
            Facade.Mediator.Remove(paramKey);
        }

    }

}

