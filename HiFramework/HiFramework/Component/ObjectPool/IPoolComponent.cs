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
  public  interface IPoolComponent
    {
        /// <summary>
        /// 创建or获取pool
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IPool<T> CreatePool<T>(IPoolHandler<T> iPoolHandler);
        /// <summary>
        /// 删除对象+删除对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        void DeletePool<T>(IPool<T> iPool);
    }
}