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
    public class Signal<T1, T2>
    {
        private Action<T1, T2> _action;

        public void AddListener(Action<T1, T2> action)
        {
            _action += action;
        }

        public void Fire(T1 t1, T2 t2)
        {
            AssertThat.IsNotNull(_action, "Action is null, add listener first");
            _action(t1, t2);
        }
    }
}
