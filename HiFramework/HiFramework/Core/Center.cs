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
    public class Center : IFramework
    {
        /// <summary>
        /// To hold all component
        /// </summary>
        private static readonly IContainer Container = new Container();

        /// <summary>
        /// Tick component to tick all components
        /// </summary>
        private TickComponent tickComponent;

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
        /// Remove component by type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Remove<T>() where T : class, IComponent
        {
            var c = Container.Get<T>();
            Container.Remove(c);
        }

        /// <summary>
        /// Remove component by instance
        /// </summary>
        /// <param name="component"></param>
        public static void Remove(IComponent component)
        {
            AssertThat.IsNotNull(component);
            Container.Remove(component);
        }

        /// <summary>
        /// Init framework
        /// </summary>
        public void Init()
        {
            tickComponent = Get<TickComponent>();
        }

        /// <summary>
        /// Tick all component
        /// </summary>
        public void Tick()
        {
            tickComponent.Tick();
        }

        /// <summary>
        /// Destory framework(destory every component)
        /// </summary>
        public void Destory()
        {
            var container = Container as Container;
            AssertThat.IsNotNull(container);
            var components = container.components;
            for (int i = 0; i < components.Count; i++)
            {
                Remove(components[i]);
            }
        }
    }
}