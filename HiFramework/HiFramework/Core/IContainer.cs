/****************************************************************************
* Description: Inferface for container
*
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IContainer : IDisposable
    {
        /// <summary>
        /// 框架初始化
        /// </summary>
        void Init();

        /// <summary>
        /// Tick维护
        /// </summary>
        void Tick(float deltaTime);

        /// <summary>
        /// 组建是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool IsComponentExist<T>(T t) where T : class, IComponent;

        /// <summary>
        /// 获取组建（自动创建）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>() where T : class, IComponent;

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Remove<T>(T t) where T : class, IComponent;

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <param name="component"></param>
        void Remove(IComponent component);
    }
}