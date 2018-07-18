/****************************************************************************
* Description: Inferface for container
*
* Author: hiramtan @live.com
****************************************************************************/

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Get component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>() where T : class, IComponent;

        /// <summary>
        /// If component exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsExist<T>() where T : class, IComponent;

        /// <summary>
        /// Remove component
        /// </summary>
        /// <param name="iComponent"></param>
        void Remove(IComponent iComponent);
    }
}