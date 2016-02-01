using UnityEngine;
using System.Collections;
using System;

namespace HFramework
{

    public abstract class View : MonoBehaviour, IView
    {
        public virtual void OnMessage(Message paramMessage)
        {

        }

        public void Register(IView paramView, IController paramController)
        {
            Facade.Mediator.Register(this, paramController);
        }
    }

}

