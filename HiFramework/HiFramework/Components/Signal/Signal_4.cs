/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using HiFramework.Assert;

namespace HiFramework.Components
{
    public class Signal_4<T1, T2, T3, T4>
    {
        private Action<T1, T2, T3, T4> _action;

        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            _action += action;
        }

        public void Fire(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            AssertThat.IsNotNull(_action, "Action is null, add listener first");
            _action(t1, t2, t3, t4);
        }
    }
}
