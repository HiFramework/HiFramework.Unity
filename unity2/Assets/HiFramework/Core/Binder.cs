/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class Binder
    {
        internal readonly Dictionary<Type, Type> BindInfos = new Dictionary<Type, Type>();

        public virtual void Init()
        {
            Bind<ITickComponent>().To<TickComponent>();
        }

        protected BindInfo<T> Bind<T>() where T : class
        {
            return new BindInfo<T>(this);
        }

        internal void SetKeyAndInstance(Type key, Type instance)
        {
            BindInfos[key] = instance;
        }
    }
}