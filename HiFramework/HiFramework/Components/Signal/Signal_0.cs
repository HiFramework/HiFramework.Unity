/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using HiFramework.Assert;

namespace HiFramework
{
    public class Signal_0
    {

        private Action _action;

        public void AddListener(Action action)
        {
            _action += action;
        }

        public void Fire()
        {
            AssertThat.IsNotNull(_action, "Action is null, add listener first");
            _action();
        }
    }
}
