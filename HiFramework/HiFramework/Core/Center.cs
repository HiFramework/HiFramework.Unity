/****************************************************************************
 * Description: 外部交互接口，初始化，tick
 * 通过该接口访问，创建，移除组件
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    /// <summary>
    /// 框架对外接口静态类
    /// </summary>
    public static class Center
    {
        private static IContainer container;
        /// <summary>
        /// 框架初始化
        /// </summary>
        public static void Init()
        {
            AssertThat.IsNull(container, "Container is not null");
            container = new Container();
            container.Init();
        }

        /// <summary>
        /// Tick维护
        /// </summary>
        public static void Tick(float deltaTime)
        {
            AssertThat.IsNotNull(container, "Container is null");
            container.Tick(deltaTime);
        }

        /// <summary>
        /// 组建是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsComponentExist<T>(T t) where T : class, IComponent
        {
            return container.IsComponentExist(t);
        }

        /// <summary>
        /// 获取组建（自动创建）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class, IComponent
        {
            return container.Get<T>();
        }

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Remove<T>(T t) where T : class, IComponent
        {
            container.Remove(t);
        }

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <param name="component"></param>
        public static void Remove(IComponent component)
        {
            container.Remove(component);
        }

        /// <summary>
        /// 销毁框架（移除组件）
        /// </summary>
        public static void Dispose()
        {
            container.Dispose();
            container = null;
        }
    }
}
