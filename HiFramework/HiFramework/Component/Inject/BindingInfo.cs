//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    /// <summary>
    /// 绑定后的信息:key,对象
    /// </summary>
    public class BindingInfo
    {
        public enum EBindType
        {
            None,
            Type,//绑定类型
            Obj,//绑定对象
        }
        public List<Type> Types { get; }
        public object Obj { get; }
        public object Key { get; }

        public BindingInfo(List<Type> types, object obj, object key = null)
        {
            Types = types;
            Obj = obj;
            Key = key;
        }
    }
}
