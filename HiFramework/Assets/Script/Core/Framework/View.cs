using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public abstract class View : MonoBehaviour, IView
    {
        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            Facade.View.Dispatch(this, paramMessage);
        }

        public virtual void OnTick(float paramTime)
        {

        }

        public void Register<T>(IView paramKey) where T : IController
        {
            Facade.View.Register<T>(paramKey);
        }

        public void Remove(IView paramView)
        {
            Facade.View.Remove(paramView);
        }
    }

}

