//****************************************************************************
// Description:
// 多个类型可以绑定同一实例,比如子类父类类型同时绑定子类实例
// 一个类型可以绑定多个实例,比如接口可以被多个实例继承,通过key来区分
// Author: hiramtan@live.com
//****************************************************************************


using System;
using System.Collections.Generic;

namespace HiFramework
{
    public interface IBinding
    {
        List<Type> Types { get; }
        Type ToType { get; }
        object ToObj { get; }
        string AsName { get; set; }
        IBinding Bind<T>();//可以填充多个类型,绑定同一实例

        IBindingAsName To<T>();
        /// <summary>
        /// to已经存在的对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        IBindingAsName To(object obj);
    }


    public interface IBindingAsName
    {
        void AsName(string name);
    }
}
