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

namespace HiFramework
{
    public interface IPool<T> where T : class, IPoolObject
    {
        /// <summary>
        /// 池中对象数量
        /// </summary>
        int Count { get; }
        T GetOneObjectFromPool();

        void RecleimThisObjectToPool(T t);

        void DisposeAll();
    }
}