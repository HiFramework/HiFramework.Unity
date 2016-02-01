using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HFramework
{
    public class Mediator : IView
    {
        private Dictionary<IView, IController> viewMap;
        public Mediator()
        {
            viewMap = new Dictionary<IView, IController>();
        }

        public void Register(IView paramView, IController paramController)
        {
            viewMap[paramView] = paramController;
        }
    }
}
