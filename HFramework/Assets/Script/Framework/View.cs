using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{

    public abstract class View : MonoBehaviour, IView, IMessage
    {
        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// controller to view
        /// </summary>
        /// <param name="paramMessage"></param>
        public void OnMessage(Message paramMessage)
        {

        }

        public void Register(IView paramView, IController paramController)
        {
            Facade.View.Register(this, paramController);
        }
        public void Remove(IView paramView)
        {
            Facade.View.Remove(paramView);
        }
    }

}

