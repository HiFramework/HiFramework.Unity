using UnityEngine;
using System.Collections;
using System;

namespace HFramework
{

    public abstract class ViewBase : MonoBehaviour, IView
    {
        public virtual void OnMessage(Message paramMessage) { }
    }

}

