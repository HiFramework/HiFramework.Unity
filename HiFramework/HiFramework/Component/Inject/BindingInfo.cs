//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// 绑定后的信息:key,对象
    /// </summary>
    public class BindingInfo : IBindInfo
    {
        public enum EBindType
        {
            None,
            Type,//绑定类型
            Obj,//绑定对象
        }
        public List<Type> Types { get; }
        public EBindType eBindType { get; }
        public Type Dest { get; }
        public object Obj { get; }
        public object Key { get; }

        public BindingInfo(List<Type> types, EBindType eBindType, Type dest, object obj, object key = null)
        {
            Types = types;
            this.eBindType = eBindType;
            Dest = dest;
            Obj = obj;
            Key = key;
        }
    }
}
