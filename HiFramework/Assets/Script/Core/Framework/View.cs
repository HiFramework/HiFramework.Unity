using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class View : MonoBehaviour, IView
    {
        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch(this, paramMessage);
        }

        public virtual void OnTick(float paramTime)
        {

        }

        public void Register<T>(IView paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public void Remove(IView paramView)
        {
            Facade.Mediator.Remove(paramView);
        }
    }

}

