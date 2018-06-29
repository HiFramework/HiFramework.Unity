/****************************************************************************
 * Description: To get and remove component
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    /// <summary>
    /// Main interface for user to get/remove component
    /// </summary>
    public static class Center
    {
        /// <summary>
        /// To hold all component
        /// </summary>
        private static readonly IContainer Container = new Container();

        /// <summary>
        /// Get component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class, IComponent
        {
            var c = Container.Get<T>();
            return c;
        }

        /// <summary>
        /// If component exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsExist<T>() where T : class, IComponent
        {
            return Container.IsExist<T>();
        }

        /// <summary>
        /// Remove component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Remove<T>() where T : class, IComponent
        {
            var c = Container.Get<T>();
            Container.Remove(c);
        }
    }
}