using UnityEngine;
using System.Collections;
using System;

namespace HFramework
{

    public abstract class View : MonoBehaviour, IView
    {
        /// <summary>
        /// ui to controller
        /// </summary>
        /// <param name="paramMessage"></param>
        public void DispatchMessage(Message paramMessage)
        {
            Facade.View.DispatchMessage(this, paramMessage);
        }

        /// <summary>
        /// controller to view
        /// </summary>
        /// <param name="paramMessage"></param>
        public void OnMessage(Message paramMessage)
        {

        }

        public void Register(IView paramView, Controller paramController)
        {
            Facade.View.Register(this, paramController);
            paramController.viewEventHandler = OnMessage;
        }
    }

}

