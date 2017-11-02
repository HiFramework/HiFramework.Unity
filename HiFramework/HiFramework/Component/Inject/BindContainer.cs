//****************************************************************************
// Description:类型可以绑定多个对象,比如接口分别被不同的对象实现
// 如果绑定多个,通过key来区分
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HiFramework
{
    class BindContainer
    {
        Dictionary<Type, List<BindInfo>> bindInfos = new Dictionary<Type, List<BindInfo>>();

        public void Bind<T>(Binding binding)
        {
            if (typeof(T).IsSubclassOf(typeof(MonoBehaviour)))
            {
                Assert.Exception("this class is sub from monobehavior, can not bind this, use MonoBase instead");
            }

        }

    }
}
